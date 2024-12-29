using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace EasyAbp.EShop.Plugins.ProductTag.MongoDB
{
    [DependsOn(
        typeof(ProductTagDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class ProductTagMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<ProductTagMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
