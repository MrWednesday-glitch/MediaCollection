namespace MediaCollection.Business.Testing.ServiceTests.FilmServiceTests;

public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_FilmRepositoryIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new FilmService(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("filmRepository");
    }
}
