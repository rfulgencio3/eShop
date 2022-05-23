using AutoMapper;
using eShop.ProductAPI.Models;

namespace eShop.ProductAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductDTO>()
                .ForMember(c => c.CategoryName, options => options.MapFrom(src => src.Category.Name));

        }
    }
}
