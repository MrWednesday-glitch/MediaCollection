using Microsoft.Extensions.DependencyInjection;

namespace MediaCollection.Business.Testing.ExtensionsTests.BusinessServiceCollectionExtensionsTests;

[ExcludeFromCodeCoverage]
public class Base
{
    public static IServiceCollection CreateServiceCollection()
    {
        IServiceCollection service = new ServiceCollection()
            .AddBusinessServices();

        return service;
    }
}
