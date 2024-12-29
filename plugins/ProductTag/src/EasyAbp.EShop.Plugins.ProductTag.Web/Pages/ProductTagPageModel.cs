using EasyAbp.EShop.Plugins.ProductTag.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.EShop.Plugins.ProductTag.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ProductTagPageModel : AbpPageModel
    {
        protected ProductTagPageModel()
        {
            LocalizationResourceType = typeof(ProductTagResource);
            ObjectMapperContext = typeof(ProductTagWebModule);
        }
    }
}