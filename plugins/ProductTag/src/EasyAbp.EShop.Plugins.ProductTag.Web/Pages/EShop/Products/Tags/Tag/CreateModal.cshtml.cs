using System.Threading.Tasks;
using EasyAbp.EShop.Plugins.ProductTag.Tags;
using EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EShop.Plugins.ProductTag.Web.Pages.EShop.Products.Tags.Tag
{
    public class CreateModalModel : ProductTagPageModel
    {
        [BindProperty]
        public CreateTagDto ViewModel { get; set; }

        private readonly ITagAppService _service;

        public CreateModalModel(ITagAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(ViewModel);
            return NoContent();
        }
    }
}