using FluentAssertions;
using MediaCollection.Data.Repositories;
using MediaCollection.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace MediaCollection.Data.Testing.ExtensionTests.DataServiceCollectionExtensionsTests;

[ExcludeFromCodeCoverage]
public class AddDataServicesTests
{
    [Fact]
    public void Should_Throw_When_ConnectionStringIsMissing()
    {
        // Arrange
        ServiceCollection services = new();
        IConfiguration configuration = CreateConfiguration(null);

        // Act
        Action act = () => services.AddDataServices(configuration);

        // Assert
        act
            .Should().Throw<ArgumentNullException>()
            .WithMessage("*No database connectionstring found*");
    }

    [Fact]
    public void Should_RegisterDbContext()
    {
        // Arrange
        ServiceCollection services = new();
        IConfiguration configuration = CreateConfiguration("Je suis une connstring.");

        // Act
        services.AddDataServices(configuration);

        // Assert
        ServiceDescriptor descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(DbContextOptions<MediaDbContext>))!;

        descriptor.Should().NotBeNull();
        descriptor!.Lifetime.Should().Be(ServiceLifetime.Scoped);
    }

    [Theory]
    [InlineData(typeof(IGameRepository), typeof(GameRepository))]
    [InlineData(typeof(IBookRepository), typeof(BookRepository))]
    [InlineData(typeof(IFilmRepository), typeof(FilmRepository))]
    [InlineData(typeof(IPublisherRepository), typeof(PublisherRepository))]
    [InlineData(typeof(IDeveloperRepository), typeof(DeveloperRepository))]
    public void Should_RegisterRepositoriesAsScoped(Type serviceType, Type implementationType)
    {
        // Arrange
        ServiceCollection services = new();
        IConfiguration configuration = CreateConfiguration();

        // Act
        services.AddDataServices(configuration);

        // Assert
        ServiceDescriptor descriptor = services.FirstOrDefault(d => d.ServiceType == serviceType)!;

        descriptor.Should().NotBeNull();
        descriptor!.ImplementationType.Should().Be(implementationType);
        descriptor.Lifetime.Should().Be(ServiceLifetime.Scoped);
    }

    [Fact]
    public void Should_ResolveRepositoriesFromServiceProvider()
    {
        // Arrange
        ServiceCollection services = new();
        IConfiguration configuration = CreateConfiguration();

        services.AddDataServices(configuration);

        ServiceProvider provider = services.BuildServiceProvider();

        // Act
        IGameRepository repo = provider.GetService<IGameRepository>()!;

        // Assert
        repo.Should().NotBeNull();
        repo.Should().BeOfType<GameRepository>();
    }

    private static IConfiguration CreateConfiguration(string? connectionString = "FakeConnectionString")
    {
        Dictionary<string, string?> configData = new()
        {
            ["ConnectionStrings:localDb"] = connectionString
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(configData!)
            .Build();
    }
}
