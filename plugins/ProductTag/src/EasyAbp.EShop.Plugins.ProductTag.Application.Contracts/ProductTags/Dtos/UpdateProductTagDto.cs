using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags.Dtos
{
    public class UpdateProductTagDto : ExtensibleEntityDto
    {
        public Guid TagId { get; set; }

        public Guid ProductId { get; set; }

        public int DisplayOrder { get; set; }
    }
}