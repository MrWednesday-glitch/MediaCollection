using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data;

public static class DataServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("localDb") ?? throw new Exception("No dbConString found.");

        services.AddDbContext<MediaDbContext>(options =>
        {
            options
            // TODO fix this
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }, ServiceLifetime.Scoped);

        // TODO Add the repositories services

        return services;
    }
}
