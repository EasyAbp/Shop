using EasyAbp.EShop.Stores.Stores;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos
{
    public class TagDto : ExtensibleFullAuditedEntityDto<Guid>, IMultiStore
    {
        public Guid StoreId { get; set; }
        
        public Guid? ParentId { get; set; }
        
        public string Code { get; set; }

        public int Level { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string MediaResources { get; set; }

        public ICollection<TagDto> Children { get; set; }
    }
}