using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags
{
    public interface IProductTagRepository : IRepository<ProductTag, Guid>
    {
        Task<List<ProductTag>> GetListByTagIdAsync(Guid tagId, Guid? storeId = null, CancellationToken cancellationToken = default);

        Task<List<ProductTag>> GetListByProductIdAsync(Guid productId, Guid? storeId = null, CancellationToken cancellationToken = default);
    }
}
