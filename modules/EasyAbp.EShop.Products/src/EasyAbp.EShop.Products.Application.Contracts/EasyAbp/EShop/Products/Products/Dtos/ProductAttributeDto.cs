﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EShop.Products.Products.Dtos
{
    public class ProductAttributeDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        
        public IEnumerable<ProductAttributeOptionDto> ProductAttributeOptions { get; set; }
    }
}