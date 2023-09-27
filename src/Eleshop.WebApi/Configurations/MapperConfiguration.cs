using AutoMapper;
using Eleshop.Domain.Entites.Accessories;
using Eleshop.Domain.Entites.Categories;
using Eleshop.Domain.Entites.Laptops;
using Eleshop.Domain.Entites.Telephones;
using Eleshop.Persistance.Dtos.Accessories;
using Eleshop.Persistance.Dtos.Categories;
using Eleshop.Persistance.Dtos.Laptops;
using Eleshop.Persistance.Dtos.Telephones;

namespace Eleshop.WebApi.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
        CreateMap<AccessoryCreateDto, Accessory>().ReverseMap();
        CreateMap<TelephoneCreateDto, Telephone>().ReverseMap();
        CreateMap<LaptopCreateDto, Laptop>().ReverseMap();
    }
}
