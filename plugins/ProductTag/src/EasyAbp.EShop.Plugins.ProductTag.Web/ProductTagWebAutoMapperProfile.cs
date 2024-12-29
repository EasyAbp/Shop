using AutoMapper;
using EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag.Web
{
    public class ProductTagWebAutoMapperProfile : Profile
    {
        public ProductTagWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<TagDto, CreateTagDto>();
            CreateMap<TagDto, UpdateTagDto>();
        }
    }
}