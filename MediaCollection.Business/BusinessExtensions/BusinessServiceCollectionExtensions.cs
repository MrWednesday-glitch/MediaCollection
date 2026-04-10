using MediaCollection.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCollection.Business.BusinessExtensions;

public static class BusinessServiceCollectionExtensions
{
    /// <summary>
    /// Adds the business logic classes to the DI container.
    /// </summary>
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IFilmService, FilmService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IDeveloperService, DeveloperService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJwtAuthorityManager, JwtAuthorityManager>();

        var jwtTokenConfiguration = configuration.GetSection("jwtTokenConfig")
            .Get<JwtTokenConfiguration>();
        services.AddSingleton(jwtTokenConfiguration);

        services.AddSingleton<DateTimeWrapper>();

        return services;
    }
}
