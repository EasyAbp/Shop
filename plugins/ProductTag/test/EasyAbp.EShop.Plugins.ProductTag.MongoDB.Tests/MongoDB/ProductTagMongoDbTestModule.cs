using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Plugins.ProductTag.MongoDB
{
    [DependsOn(
        typeof(ProductTagTestBaseModule),
        typeof(ProductTagMongoDbModule)
        )]
    public class ProductTagMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}