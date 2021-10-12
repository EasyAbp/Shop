using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.Products.CacheItems;
using EasyAbp.EShop.Products.Products.Dtos;
using EasyAbp.EShop.Products.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Uow;

namespace EasyAbp.EShop.Products.Products
{
    public class ProductViewAppService : ReadOnlyAppService<ProductView, ProductViewDto, Guid, GetProductListInput>,
        IProductViewAppService
    {
        protected override string GetPolicyName { get; set; } = null;
        protected override string GetListPolicyName { get; set; } = null;

        private readonly IProductViewCacheKeyProvider _productViewCacheKeyProvider;
        private readonly IDistributedCache<ProductViewCacheItem> _cache;
        private readonly IProductRepository _productRepository;
        private readonly IProductViewRepository _repository;
        
        public ProductViewAppService(
            IProductViewCacheKeyProvider productViewCacheKeyProvider,
            IDistributedCache<ProductViewCacheItem> cache,
            IProductRepository productRepository,
            IProductViewRepository repository) : base(repository)
        {
            _productViewCacheKeyProvider = productViewCacheKeyProvider;
            _cache = cache;
            _productRepository = productRepository;
            _repository = repository;
        }
        
        protected override async Task<IQueryable<ProductView>> CreateFilteredQueryAsync(GetProductListInput input)
        {
            var query = input.CategoryId.HasValue
                ? _repository.WithDetails(input.CategoryId.Value)
                : (await _repository.WithDetailsAsync());

            return query
                .Where(x => x.StoreId == input.StoreId)
                .WhereIf(!input.ShowHidden, x => !x.IsHidden);
        }

        public override async Task<PagedResultDto<ProductViewDto>> GetListAsync(GetProductListInput input)
        {
            await CheckGetListPolicyAsync();

            if (await _cache.GetAsync(await GetCacheKeyAsync(input.StoreId), true) == null)
            {
                await BuildStoreProductViewsAsync(input.StoreId);
            }
            
            var query = await CreateFilteredQueryAsync(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var productViews = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(productViews);

            return new PagedResultDto<ProductViewDto>(
                totalCount,
                entityDtos
            );
        }

        protected virtual async Task<string> GetCacheKeyAsync(Guid storeId)
        {
            return await _productViewCacheKeyProvider.GetCacheKeyAsync(storeId);
        }

        public override async Task<ProductViewDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var productView = await GetEntityByIdAsync(id);

            if (await _cache.GetAsync(await GetCacheKeyAsync(productView.StoreId), true) != null)
            {
                return await base.GetAsync(id);
            }

            await BuildStoreProductViewsAsync(productView.StoreId);

            productView = await GetEntityByIdAsync(id);
            
            return await MapToGetOutputDtoAsync(productView);
        }

        protected virtual async Task BuildStoreProductViewsAsync(Guid storeId)
        {
            var products = await _productRepository.GetListAsync(x => x.StoreId == storeId);

            using var uow = UnitOfWorkManager.Begin(true, true);

            await _repository.DeleteAsync(x => x.StoreId == storeId, true);

            foreach (var product in products)
            {
                await _repository.InsertAsync(ObjectMapper.Map<Product, ProductView>(product));
            }

            await uow.CompleteAsync();

            await _cache.SetAsync(await GetCacheKeyAsync(storeId), new ProductViewCacheItem(),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Convert.ToInt32(
                        await SettingProvider.GetOrNullAsync(ProductsSettings.ProductView.CacheDurationSeconds)))
                });
        }
    }
}
