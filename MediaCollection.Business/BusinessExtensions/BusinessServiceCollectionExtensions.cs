using MediaCollection.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCollection.Business.BusinessExtensions;

public static class BusinessServiceCollectionExtensions
{
    /// <summary>
    /// Adds the business logic classes to the DI container.
    /// </summary>
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IFilmService, FilmService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IDeveloperService, DeveloperService>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddSingleton<DateTimeWrapper>();

        return services;
    }
}
