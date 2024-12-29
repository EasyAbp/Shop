using EasyAbp.EShop.Plugins.ProductTag.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.EShop.Plugins.ProductTag.Permissions
{
    public class ProductTagPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(ProductTagPermissions.GroupName, L("Permission:ProductTag"));
            
            var tags = moduleGroup.AddPermission(ProductTagPermissions.Tags.Default, L("Permission:Tag"));
            tags.AddChild(ProductTagPermissions.Tags.Create, L("Permission:Create"));
            tags.AddChild(ProductTagPermissions.Tags.Update, L("Permission:Update"));
            tags.AddChild(ProductTagPermissions.Tags.Delete, L("Permission:Delete"));
            tags.AddChild(ProductTagPermissions.Tags.CrossStore, L("Permission:CrossStore"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductTagResource>(name);
        }
    }
}