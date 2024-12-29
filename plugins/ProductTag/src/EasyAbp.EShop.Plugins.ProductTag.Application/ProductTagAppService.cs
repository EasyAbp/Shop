using EasyAbp.EShop.Plugins.ProductTag.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    public abstract class ProductTagAppService : ApplicationService
    {
        protected ProductTagAppService()
        {
            LocalizationResource = typeof(ProductTagResource);
            ObjectMapperContext = typeof(ProductTagApplicationModule);
        }
    }
}
