using System;
using System.Threading.Tasks;
using EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag.Tags
{
    [RemoteService(Name = "TagService")]
    [Route("/api/eShop/products/tag")]
    public class TagController : ProductTagBaseController, ITagAppService
    {
        private readonly ITagAppService _service;

        public TagController(ITagAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<TagDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<TagDto>> GetListAsync(GetTagListDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<TagDto> CreateAsync(CreateTagDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<TagDto> UpdateAsync(Guid id, UpdateTagDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}