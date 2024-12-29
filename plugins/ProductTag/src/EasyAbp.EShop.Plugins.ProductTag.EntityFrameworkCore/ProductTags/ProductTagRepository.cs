using EasyAbp.EShop.Plugins.ProductTag.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags
{
    public class ProductTagRepository : EfCoreRepository<ProductTagDbContext, ProductTag, Guid>, IProductTagRepository
    {
        public ProductTagRepository(IDbContextProvider<ProductTagDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<List<ProductTag>> GetListByTagIdAsync(Guid categoryId, Guid? storeId = null,
            CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            if (storeId.HasValue)
            {
                queryable = queryable.Where(x => x.StoreId == storeId.Value);
            }

            return await queryable.Where(pc => pc.TagId == categoryId).ToListAsync(cancellationToken);
        }

        public virtual async Task<List<ProductTag>> GetListByProductIdAsync(Guid productId, Guid? storeId = null,
            CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            if (storeId.HasValue)
            {
                queryable = queryable.Where(x => x.StoreId == storeId.Value);
            }

            return await queryable.Where(pc => pc.ProductId == productId).ToListAsync(cancellationToken);
        }
    }
}
