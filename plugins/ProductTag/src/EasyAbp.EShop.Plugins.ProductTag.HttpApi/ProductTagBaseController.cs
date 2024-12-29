using EasyAbp.EShop.Plugins.ProductTag.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    public abstract class ProductTagBaseController : AbpController
    {
        protected ProductTagBaseController()
        {
            LocalizationResource = typeof(ProductTagResource);
        }
    }
}
