using EasyAbp.EShop.Plugins.ProductTag.ProductTags.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags
{
    public interface IProductTagAppService :
        IReadOnlyAppService<
            ProductTagDto,
            Guid,
            GetProductTagListDto>,
        IUpdateAppService<ProductTagDto, Guid, UpdateProductTagDto>
    {
        Task UpdateAsync(CreateUpdateProductTagsDto input);
    }
}
