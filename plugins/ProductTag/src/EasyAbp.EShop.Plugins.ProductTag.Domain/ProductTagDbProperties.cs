namespace EasyAbp.EShop.Plugins.ProductTag
{
    public static class ProductTagDbProperties
    {
        public static string DbTablePrefix { get; set; } = "ProductTag";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "ProductTag";
    }
}
