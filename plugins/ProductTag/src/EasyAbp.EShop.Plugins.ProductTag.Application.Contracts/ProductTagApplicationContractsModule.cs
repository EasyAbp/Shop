using EasyAbp.EShop.Stores;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    [DependsOn(
        typeof(ProductTagDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule),
        typeof(EShopStoresDomainSharedModule)
        )]
    public class ProductTagApplicationContractsModule : AbpModule
    {

    }
}
