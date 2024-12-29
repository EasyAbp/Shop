using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.EShop.Plugins.ProductTag.MongoDB
{
    public class ProductTagMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public ProductTagMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}