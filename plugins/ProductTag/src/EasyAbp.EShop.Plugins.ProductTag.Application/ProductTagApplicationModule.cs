using EasyAbp.EShop.Products;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    [DependsOn(
        typeof(ProductTagDomainModule),
        typeof(ProductTagApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(EShopProductsDomainModule)
        )]
    public class ProductTagApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ProductTagApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ProductTagApplicationModule>(validate: true);
            });
        }
    }
}
