using MediaCollection.Business.BusinessExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCollection.Business.Testing.ExtensionsTests.BusinessServiceCollectionExtensionsTests;

[ExcludeFromCodeCoverage]
public class Base
{
    public static IServiceCollection CreateServiceCollection()
    {
        IConfiguration configuration = CreateConfiguration();

        IServiceCollection service = new ServiceCollection()
            .AddBusinessServices(configuration);

        return service;
    }

    private static IConfiguration CreateConfiguration()
    {
        Dictionary<string, string?> configData = new()
        {
            ["jwtTokenConfig:Issuer"] = "MediaCollection",
            ["jwtTokenConfig:Audience"] = "Bob",
            ["jwtTokenConfig:Secret"] = "MyCabbages!",
            ["jwtTokenConfig:AccessTokenExpiration"] = "30",
            ["jwtTokenConfig:RefreshTokenExpiration"] = "525600"
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(configData!)
            .Build();
    }
}
