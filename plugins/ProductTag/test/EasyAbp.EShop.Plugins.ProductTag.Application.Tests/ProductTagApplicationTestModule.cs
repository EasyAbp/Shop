using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    [DependsOn(
        typeof(ProductTagApplicationModule),
        typeof(ProductTagDomainTestModule)
        )]
    public class ProductTagApplicationTestModule : AbpModule
    {

    }
}
