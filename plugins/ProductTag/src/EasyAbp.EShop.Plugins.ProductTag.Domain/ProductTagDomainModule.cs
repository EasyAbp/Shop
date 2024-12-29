using EasyAbp.Abp.Trees;
using EasyAbp.EShop.Stores;
using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    [DependsOn(
        typeof(ProductTagDomainSharedModule),
        typeof(AbpTreesDomainModule),
        typeof(EShopStoresDomainSharedModule)
        )]
    public class ProductTagDomainModule : AbpModule
    {

    }
}
