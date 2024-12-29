using EasyAbp.EShop.Plugins.ProductTag.Tags;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.EShop.Plugins.ProductTag.EntityFrameworkCore
{
    [ConnectionStringName(ProductTagDbProperties.ConnectionStringName)]
    public class ProductTagDbContext : AbpDbContext<ProductTagDbContext>, IProductTagDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTags.ProductTag> ProductTags { get; set; }

        public ProductTagDbContext(DbContextOptions<ProductTagDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureProductTag();
        }
    }
}