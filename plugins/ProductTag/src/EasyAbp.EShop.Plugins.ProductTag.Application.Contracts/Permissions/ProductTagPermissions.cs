using Volo.Abp.Reflection;

namespace EasyAbp.EShop.Plugins.ProductTag.Permissions
{
    public class ProductTagPermissions
    {
        public const string GroupName = "EasyAbp.EShop.ProductTag";

        public class Tags
        {
            public const string Default = GroupName + ".Tag";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string CrossStore = Default + ".CrossStore";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductTagPermissions));
        }
    }
}