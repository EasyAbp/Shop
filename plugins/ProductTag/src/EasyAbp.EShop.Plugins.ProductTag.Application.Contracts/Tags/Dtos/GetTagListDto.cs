using System;
using System.ComponentModel.DataAnnotations;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos
{
    public class GetTagListDto : PagedAndSortedResultRequestDto, IMultiStore
    {
        [Required]
        public Guid StoreId { get; set; }

        public bool ShowHidden { get; set; }
    }
}