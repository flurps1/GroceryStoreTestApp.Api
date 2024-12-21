using AutoMapper;
using DataAccess;

namespace GroceryStoreTestApp.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductModel, ProductDto>();
        CreateMap<CreatedProductDto, ProductModel>();
        CreateMap<UpdateProductDto, ProductModel>();
    }
}