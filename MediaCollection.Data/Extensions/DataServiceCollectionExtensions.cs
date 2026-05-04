using MediaCollection.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCollection.Data.Extensions;

public static class DataServiceCollectionExtensions
{
    /// <summary>
    /// Add the DbContext and the repositories to the DI Container.
    /// </summary>
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("localDb")
            ?? throw new ArgumentNullException("No database connectionstring found.");

        services.AddDbContext<MediaDbContext>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }, ServiceLifetime.Scoped);
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<MediaDbContext>();

        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IFilmRepository, FilmRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IDeveloperRepository, DeveloperRepository>();

        return services;
    }
}
