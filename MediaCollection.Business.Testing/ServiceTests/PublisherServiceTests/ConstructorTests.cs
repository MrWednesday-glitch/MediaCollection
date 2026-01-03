namespace MediaCollection.Business.Testing.ServiceTests.PublisherServiceTests;

[ExcludeFromCodeCoverage]
public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_PublisherRepositoryIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new PublisherService(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("publisherRepository");
    }

    // TODO Test happyflow
    // TODO Test distinct
    // TODO Test filter
}
