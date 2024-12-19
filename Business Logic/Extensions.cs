using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Business_Logic;

public static class Extensions
{
    public static IServiceCollection AddLogicServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService>();
        return serviceCollection;
    }
}