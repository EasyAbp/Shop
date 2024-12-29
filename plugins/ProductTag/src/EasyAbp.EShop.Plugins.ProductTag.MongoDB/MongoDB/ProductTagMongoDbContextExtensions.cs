using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.EShop.Plugins.ProductTag.MongoDB
{
    public static class ProductTagMongoDbContextExtensions
    {
        public static void ConfigureProductTag(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ProductTagMongoModelBuilderConfigurationOptions(
                ProductTagDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}