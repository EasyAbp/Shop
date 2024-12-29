using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.EShop.Plugins.ProductTag.Tags
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<List<Tag>> GetListByAsync(Guid storeId, bool includeDetails = false, CancellationToken cancellationToken = default);
    }
}
