using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.EShop.Plugins.ProductTag.MongoDB
{
    [ConnectionStringName(ProductTagDbProperties.ConnectionStringName)]
    public interface IProductTagMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
