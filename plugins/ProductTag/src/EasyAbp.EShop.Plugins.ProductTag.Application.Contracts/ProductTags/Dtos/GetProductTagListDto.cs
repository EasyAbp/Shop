using System;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag.ProductTags.Dtos
{
    public class GetProductTagListDto : PagedAndSortedResultRequestDto, IMultiStore
    {
        public Guid StoreId { get; set; }

        public Guid? TagId { get; set; }

        public Guid? ProductId { get; set; }
    }
}