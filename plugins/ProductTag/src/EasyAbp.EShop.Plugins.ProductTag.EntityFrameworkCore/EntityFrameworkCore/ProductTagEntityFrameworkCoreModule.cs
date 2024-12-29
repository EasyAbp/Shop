using EasyAbp.Abp.Trees.EntityFrameworkCore;
using EasyAbp.EShop.Plugins.ProductTag.ProductTags;
using EasyAbp.EShop.Plugins.ProductTag.Tags;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Plugins.ProductTag.EntityFrameworkCore
{
    [DependsOn(
        typeof(ProductTagDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpTreesEntityFrameworkCoreModule)
    )]
    public class ProductTagEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ProductTagDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Tag, TagRepository>();
                options.AddRepository<ProductTags.ProductTag, ProductTagRepository>();
            });
        }
    }
}