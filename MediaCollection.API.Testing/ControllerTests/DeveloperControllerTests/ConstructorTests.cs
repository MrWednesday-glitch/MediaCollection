namespace MediaCollection.API.Testing.ControllerTests.DeveloperControllerTests;

[ExcludeFromCodeCoverage]
public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_DeveloperServiceIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new DeveloperController(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("developerService");
    }
}
