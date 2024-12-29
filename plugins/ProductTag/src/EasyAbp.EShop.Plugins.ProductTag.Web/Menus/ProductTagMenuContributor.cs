using System.Collections.Generic;
using EasyAbp.EShop.Plugins.ProductTag.Localization;
using EasyAbp.EShop.Plugins.ProductTag.Permissions;
using EasyAbp.EShop.Products.Web.Menus;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.EShop.Plugins.ProductTag.Web.Menus
{
    public class ProductTagMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            //Add main menu items.
            var l = context.GetLocalizer<ProductTagResource>();

            var eShopMenuItem = context.Menu.Items.GetOrAdd(i => i.Name == ProductsMenus.ModuleGroupPrefix,
                () => new ApplicationMenuItem(ProductsMenus.ModuleGroupPrefix, l["Menu:EasyAbpEShop"]));

            var productManagementMenuItem = eShopMenuItem.Items.GetOrAdd(x => x.Name == ProductsMenus.Prefix,
                () => new ApplicationMenuItem(ProductsMenus.Prefix, l["Menu:ProductManagement"]));

            if (await context.IsGrantedAsync(ProductTagPermissions.Tags.Default))
            {
                productManagementMenuItem.AddItem(
                    new ApplicationMenuItem(ProductTagMenus.Tag, l["Menu:Tag"], "/EShop/Products/Tags/Tag")
                );
            }
        }
    }
}