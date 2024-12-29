using EasyAbp.EShop.Plugins.ProductTag.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ProductTagEntityFrameworkCoreTestModule)
        )]
    public class ProductTagDomainTestModule : AbpModule
    {
        
    }
}
