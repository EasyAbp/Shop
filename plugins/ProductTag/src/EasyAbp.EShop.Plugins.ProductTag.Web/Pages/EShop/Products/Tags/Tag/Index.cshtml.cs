using EasyAbp.EShop.Stores.StoreOwners;
using EasyAbp.EShop.Stores.StoreOwners.Dtos;
using EasyAbp.EShop.Stores.Stores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyAbp.EShop.Plugins.ProductTag.Web.Pages.EShop.Products.Tags.Tag
{
    public class IndexModel : ProductTagPageModel
    {
        private readonly IStoreAppService _storeAppService;
        private readonly IStoreOwnerAppService _storeOwnerAppService;

        [BindProperty(SupportsGet = true)]
        public Guid? StoreId { get; set; }

        public string StoreName { get; set; }

        public IndexModel(IStoreAppService storeAppService,
            IStoreOwnerAppService storeOwnerAppService)
        {
            _storeAppService = storeAppService;
            _storeOwnerAppService = storeOwnerAppService;
        }

        public virtual async Task OnGetAsync()
        {
            //TODO: Need to handle: when StoreId is empty, and current user owns multiple store
            if (!StoreId.HasValue && CurrentUser.Id.HasValue)
            {
                var storeOwners = await _storeOwnerAppService.GetListAsync(new GetStoreOwnerListDto
                {
                    OwnerId = CurrentUser.Id.Value,
                });

                StoreId = storeOwners.Items.FirstOrDefault()?.StoreId;
            }

            //show default store
            if (!StoreId.HasValue)
            {
                var defaultStore = await _storeAppService.GetDefaultAsync();
                StoreId = defaultStore.Id;
            }

            StoreName = (await _storeAppService.GetAsync(StoreId.Value)).Name;
        }
    }
}
