using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class Extensions
{
    public static IServiceCollection AddLogicServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<ICartService, CartService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        return serviceCollection;
    }
}