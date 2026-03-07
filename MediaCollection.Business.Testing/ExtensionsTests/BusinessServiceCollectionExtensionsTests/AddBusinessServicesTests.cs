using Microsoft.Extensions.DependencyInjection;

namespace MediaCollection.Business.Testing.ExtensionsTests.BusinessServiceCollectionExtensionsTests;

[ExcludeFromCodeCoverage]
public class AddBusinessServicesTests : Base
{
    public AddBusinessServicesTests()
    {
    }

    [Theory]
    [InlineData(typeof(IGameService), typeof(GameService))]
    [InlineData(typeof(IBookService), typeof(BookService))]
    [InlineData(typeof(IFilmService), typeof(FilmService))]
    [InlineData(typeof(IPublisherService), typeof(PublisherService))]
    [InlineData(typeof(IDeveloperService), typeof(DeveloperService))]
    public void Should_AddServicesAndTheirDependencies(Type serviceType, Type implementationType)
    {
        // -- Arrange

        // -- Act
        IServiceCollection serviceCollection = CreateServiceCollection();

        // -- Assert
        ServiceDescriptor descriptor = serviceCollection.FirstOrDefault(d => d.ServiceType == serviceType)!;

        descriptor.Should().NotBeNull();
        descriptor!.ImplementationType.Should().Be(implementationType);
        descriptor.Lifetime.Should().Be(ServiceLifetime.Scoped);
    }
}
