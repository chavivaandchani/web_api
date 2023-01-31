using AutoMapper;
using Entity;
using DTO;

namespace DrinkStore
{
    public class Mapper : Profile
    {

        public Mapper()
        {
            //CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ForMember(dest => dest.CategoryName, src => src.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, UserDTO>();
        }
    }
}
