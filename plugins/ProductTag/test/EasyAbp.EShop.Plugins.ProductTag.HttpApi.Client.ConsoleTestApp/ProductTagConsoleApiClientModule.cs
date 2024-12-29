using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    [DependsOn(
        typeof(ProductTagHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ProductTagConsoleApiClientModule : AbpModule
    {
        
    }
}
