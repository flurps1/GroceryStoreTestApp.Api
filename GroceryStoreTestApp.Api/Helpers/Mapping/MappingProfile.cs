using AutoMapper;
using DataAccess;

namespace GroceryStoreTestApp.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Products

        CreateMap<ProductModel, ProductDto>()
            .ReverseMap();
        CreateMap<CreatedProductDto, ProductModel>()
            .ReverseMap();
        CreateMap<UpdateProductDto, ProductModel>()
            .ReverseMap();
        
        #endregion

        #region Cart

        CreateMap<CartItemModel, CartItemDto>()
            .ReverseMap();
        CreateMap<CreateCartItemDto, CartItemModel>().ReverseMap();
        CreateMap<CreateCartItemDto, CartItemModel>().ReverseMap();

        #endregion

        #region Users

        CreateMap<UserModel, UserProfileDto>()
            .ReverseMap();
        
        #endregion
    }
}