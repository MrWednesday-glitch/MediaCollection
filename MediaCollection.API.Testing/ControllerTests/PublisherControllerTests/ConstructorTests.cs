namespace MediaCollection.API.Testing.ControllerTests.PublisherControllerTests;

public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_PublisherServiceIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new PublisherController(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("publisherService");
    }
}
