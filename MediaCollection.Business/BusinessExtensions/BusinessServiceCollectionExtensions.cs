using MediaCollection.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCollection.Business;

// TODO Unit test
// TODO Summaries
public static class BusinessServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IFilmService, FilmService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IDeveloperService, DeveloperService>();

        return services;
    }
}
