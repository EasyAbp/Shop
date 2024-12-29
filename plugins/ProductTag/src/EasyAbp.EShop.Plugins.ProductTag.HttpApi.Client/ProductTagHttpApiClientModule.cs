using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    [DependsOn(
        typeof(ProductTagApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ProductTagHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ProductTag";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ProductTagApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
