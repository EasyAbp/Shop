using EasyAbp.EShop.Plugins.ProductTag.ProductTags.Dtos;
using EasyAbp.EShop.Plugins.ProductTag.Tags;
using EasyAbp.EShop.Products.Permissions;
using EasyAbp.EShop.Products.ProductStores;
using EasyAbp.EShop.Stores.Permissions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.Products;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags
{
    public class ProductTagAppService : ReadOnlyAppService<ProductTag, ProductTagDto, Guid, GetProductTagListDto>,
        IProductTagAppService
    {
        private readonly IProductTagRepository _repository;
        private readonly ITagRepository _tagRepository;
        private readonly IProductStoreRepository _productStoreRepository;

        public ProductTagAppService(IProductTagRepository repository,
            ITagRepository tagRepository,
            IProductStoreRepository productStoreRepository) : base(repository)
        {
            _repository = repository;
            _tagRepository = tagRepository;
            _productStoreRepository = productStoreRepository;
        }

        protected override string GetListPolicyName { get; set; } = ProductsPermissions.Products.Default;
        protected string UpdatePolicyName { get; set; } = ProductsPermissions.Products.Update;

        [RemoteService(false)]
        public override Task<ProductTagDto> GetAsync(Guid id)
        {
            throw new NotSupportedException();
        }

        public override async Task<PagedResultDto<ProductTagDto>> GetListAsync(GetProductTagListDto input)
        {
            await CheckGetListPolicyAsync();

            await AuthorizationService.CheckStoreOwnerAsync(input.StoreId, GetListPolicyName);

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);

            return new PagedResultDto<ProductTagDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList());
        }

        protected override IQueryable<ProductTag> CreateFilteredQuery(GetProductTagListDto input)
        {
            var queryable = Repository.AsQueryable();

            queryable = queryable.Where(x => x.StoreId == input.StoreId);

            if (input.TagId.HasValue)
            {
                queryable = queryable.Where(x => x.TagId == input.TagId);
            }

            if (input.ProductId.HasValue)
            {
                queryable = queryable.Where(x => x.ProductId == input.ProductId);
            }

            return queryable;
        }

        public async Task<ProductTagDto> UpdateAsync(Guid id, UpdateProductTagDto input)
        {
            var entity = await GetEntityByIdAsync(id);

            await AuthorizationService.CheckStoreOwnerAsync(entity.StoreId, UpdatePolicyName);

            MapToEntity(input, entity);
            await _repository.UpdateAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        public async Task UpdateAsync(CreateUpdateProductTagsDto input)
        {
            await AuthorizationService.CheckStoreOwnerAsync(input.StoreId, UpdatePolicyName);

            var productStore = await _productStoreRepository.GetAsync(input.ProductId, input.StoreId, false);

            if (!productStore.IsOwner)
            {
                throw new StoreIsNotProductOwnerException(input.ProductId, input.StoreId);
            }

            input.TagIds ??= new List<Guid>();

            var storeTags = (await _tagRepository.GetListByAsync(input.StoreId)).Select(x => x.Id);

            var productTags = await _repository.GetListByProductIdAsync(input.ProductId, input.StoreId);

            foreach (var productTag in productTags.Where(x => !input.TagIds.Contains(x.TagId)))
            {
                await _repository.DeleteAsync(productTag, true);
            }

            foreach (var tagId in input.TagIds.Except(productTags.Select(x => x.TagId).Concat(storeTags)))
            {
                await _repository.InsertAsync(
                    new ProductTag(GuidGenerator.Create(), CurrentTenant.Id, tagId, input.ProductId), true);
            }
        }

        protected virtual ProductTag MapToEntity(UpdateProductTagDto input, ProductTag entity)
        {
            return ObjectMapper.Map(input, entity);
        }
    }
}
