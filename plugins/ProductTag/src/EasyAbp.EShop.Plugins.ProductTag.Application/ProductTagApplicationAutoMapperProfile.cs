using AutoMapper;
using EasyAbp.EShop.Plugins.ProductTag.ProductTags.Dtos;
using EasyAbp.EShop.Plugins.ProductTag.Tags;
using EasyAbp.EShop.Plugins.ProductTag.Tags.Dtos;

namespace EasyAbp.EShop.Plugins.ProductTag
{
    public class ProductTagApplicationAutoMapperProfile : Profile
    {
        public ProductTagApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CreateTagDto, TagDto>(MemberList.Source);
            CreateMap<UpdateTagDto, TagDto>(MemberList.Source);
            CreateMap<Tag, TagDto>();
            CreateMap<CreateTagDto, Tag>(MemberList.Source);
            CreateMap<UpdateTagDto, Tag>(MemberList.Source);

            CreateMap<ProductTags.ProductTag, ProductTagDto>();
            CreateMap<UpdateProductTagDto, ProductTags.ProductTag>(MemberList.Source);
        }
    }
}