using System;
using EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.EShop.Plugins.ProductTag.Tags
{
    public interface ITagAppService : ICrudAppService<
        TagDto,
        Guid,
        GetTagListDto,
        CreateTagDto,
        UpdateTagDto>
    {
    }
}
