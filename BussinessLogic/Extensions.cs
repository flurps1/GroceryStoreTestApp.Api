
using Microsoft.Extensions.DependencyInjection;

namespace BussinessLogic;

public static class Extensions
{
    public static IServiceCollection AddLogicServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService>();
        return serviceCollection;
    }
}