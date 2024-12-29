using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.EShop.Plugins.ProductTag.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class ProductTagDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProductTagDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ProductTagResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ProductTag");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ProductTag", typeof(ProductTagResource));
            });
        }
    }
}
