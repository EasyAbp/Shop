using System;
using System.Collections.Generic;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags.Dtos
{
    public class CreateUpdateProductTagsDto : ExtensibleObject
    {
        public Guid StoreId { get; set; }

        public Guid ProductId { get; set; }

        public List<Guid> TagIds { get; set; }
    }
}
