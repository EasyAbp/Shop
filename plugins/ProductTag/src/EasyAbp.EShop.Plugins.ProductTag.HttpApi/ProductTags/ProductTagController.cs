using EasyAbp.EShop.Plugins.ProductTag.ProductTags.Dtos;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags
{
    [RemoteService(Name = "ProductTagService")]
    [Route("/api/eShop/products/productTag")]
    public class ProductTagController : ProductTagBaseController, IProductTagAppService
    {
        private readonly IProductTagAppService _service;

        public ProductTagController(IProductTagAppService service)
        {
            _service = service;
        }

        [HttpPut]
        public virtual Task UpdateAsync(CreateUpdateProductTagsDto input)
        {
            return _service.UpdateAsync(input);
        }

        [RemoteService(false)]
        [NonAction]
        public Task<ProductTagDto> GetAsync(Guid id)
        {
            throw new NotSupportedException();
        }

        [HttpGet]
        public Task<PagedResultDto<ProductTagDto>> GetListAsync(GetProductTagListDto input)
        {
            return _service.GetListAsync(input);
        }


        [HttpPut]
        [Route("{id}")]
        public Task<ProductTagDto> UpdateAsync(Guid id, UpdateProductTagDto input)
        {
            return _service.UpdateAsync(id, input);
        }
    }
}