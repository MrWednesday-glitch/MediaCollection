namespace MediaCollection.Business.Testing.ServiceTests.GameServiceTests;

public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_GameRepositoryIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new GameService(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("gameRepository");
    }
}
