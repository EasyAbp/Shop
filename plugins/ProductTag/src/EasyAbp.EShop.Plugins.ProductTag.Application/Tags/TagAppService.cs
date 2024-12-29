using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.EShop.Plugins.ProductTag.Permissions;
using EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos;
using EasyAbp.EShop.Stores.Stores;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Linq;

namespace EasyAbp.EShop.Plugins.ProductTag.Tags
{
    public class TagAppService : MultiStoreCrudAppService<Tag, TagDto, Guid, GetTagListDto, CreateTagDto, UpdateTagDto>,
        ITagAppService
    {
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        protected override string CreatePolicyName { get; set; } = ProductTagPermissions.Tags.Create;
        protected override string DeletePolicyName { get; set; } = ProductTagPermissions.Tags.Delete;
        protected override string UpdatePolicyName { get; set; } = ProductTagPermissions.Tags.Update;
        protected override string GetPolicyName { get; set; } = ProductTagPermissions.Tags.Default;
        protected override string GetListPolicyName { get; set; } = ProductTagPermissions.Tags.Default;

        protected override string CrossStorePolicyName { get; set; } = ProductTagPermissions.Tags.CrossStore;

        public TagAppService(ITagRepository repository,
            [NotNull] IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _asyncQueryableExecuter = asyncQueryableExecuter ?? throw new ArgumentNullException(nameof(asyncQueryableExecuter));
        }

        protected override IQueryable<Tag> CreateFilteredQuery(GetTagListDto input)
        {
            var query = base.CreateFilteredQuery(input);

            query = query.Where(x => x.StoreId == input.StoreId);

            return input.ShowHidden ? query : query.Where(x => !x.IsHidden);
        }
    }
}
