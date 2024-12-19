﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<AppContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Port=5433;Database=Api;Username=postgres;Password=1234");
        });

        return serviceCollection;
    }
}