using EasyAbp.EShop.Plugins.ProductTag.Tags;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.EShop.Plugins.ProductTag.EntityFrameworkCore
{
    [ConnectionStringName(ProductTagDbProperties.ConnectionStringName)]
    public interface IProductTagDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
           DbSet<Tag> Tags { get; set; }
           DbSet<ProductTags.ProductTag> ProductTags { get; set; }
    }
}