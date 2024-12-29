using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.EShop.Plugins.ProductTag.MongoDB
{
    [ConnectionStringName(ProductTagDbProperties.ConnectionStringName)]
    public class ProductTagMongoDbContext : AbpMongoDbContext, IProductTagMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureProductTag();
        }
    }
}