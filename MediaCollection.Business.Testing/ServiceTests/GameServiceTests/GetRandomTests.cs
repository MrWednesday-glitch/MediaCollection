namespace MediaCollection.Business.Testing.ServiceTests.GameServiceTests;

[ExcludeFromCodeCoverage]
public class GetRandomTests
{
    [Fact]
    public async Task Should_ReturnARandomGame()
    {
        // -- Arrange
        List<Game> mockedGames =
        [
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Call of Duty",
                Developer = new Developer
                {
                    Name = "DeveloperA"
                },
                Publisher = new Publisher
                {
                    Name = "PublisherA"
                },
                Finished = false,
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Atelier Ryza",
                Developer = new Developer
                {
                    Name = "DeveloperB"
                },
                Publisher = new Publisher
                {
                    Name = "PublisherA"
                },
                Finished = true,
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Burnout",
                Developer = new Developer
                {
                    Name = "DeveloperC"
                },
                Publisher = new Publisher
                {
                    Name = "PublisherB"
                },
                Finished = false,
            },
        ];
        Mock<IGameRepository> mockedGameRepository = new();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        mockedGameRepository.Setup(gRepo => gRepo.Get()).ReturnsAsync(mockedGames.AsQueryable);

        // -- Act
        Game? randomGame = await gameService.GetRandom();

        // -- Assert
        randomGame
            .Should().NotBeNull()
            .And.Match<Game>(g => !string.IsNullOrEmpty(g.Name));
    }

    [Fact]
    public async Task Should_ReturnNull_If_NoUnfinishedGamesAreInTheDatabase()
    {
        // -- Arrange
        List<Game> mockedGames =
        [
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Call of Duty",
                Developer = new Developer
                {
                    Name = "DeveloperA"
                },
                Publisher = new Publisher
                {
                    Name = "PublisherA"
                },
                Finished = true,
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Atelier Ryza",
                Developer = new Developer
                {
                    Name = "DeveloperB"
                },
                Publisher = new Publisher
                {
                    Name = "PublisherA"
                },
                Finished = true,
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Burnout",
                Developer = new Developer
                {
                    Name = "DeveloperC"
                },
                Publisher = new Publisher
                {
                    Name = "PublisherB"
                },
                Finished = true,
            },
        ];
        Mock<IGameRepository> mockedGameRepository = new();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        mockedGameRepository.Setup(gRepo => gRepo.Get()).ReturnsAsync(mockedGames.AsQueryable);

        // -- Act
        Game? randomGame = await gameService.GetRandom();

        // -- Assert
        randomGame.Should().BeNull();
    }
}
