namespace MediaCollection.Business.Testing.ServiceTests.DeveloperServiceTests;

[ExcludeFromCodeCoverage]
public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_DeveloperRepositoryIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new DeveloperService(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("developerRepository");
    }
}
