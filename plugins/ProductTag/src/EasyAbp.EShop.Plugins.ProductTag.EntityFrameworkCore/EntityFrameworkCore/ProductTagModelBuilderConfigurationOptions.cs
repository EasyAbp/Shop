using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.EShop.Plugins.ProductTag.EntityFrameworkCore
{
    public class ProductTagModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ProductTagModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}