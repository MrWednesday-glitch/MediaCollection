namespace MediaCollection.Business.Testing.ServiceTests.GameServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests
{
    private readonly List<Game> _mockedGames =
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
            }
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
            }
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
            }
        },
    ];

    [Fact]
    public async Task Should_ReturnCorrectAmountOfGames()
    {
        // -- Arrange
        var mockedGameRepository = new Mock<IGameRepository>();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        mockedGameRepository.Setup(gRepo => gRepo.Get()).ReturnsAsync(_mockedGames.AsQueryable);
        var pageNumber = 1;
        var pageSize = 10;

        // -- Act
        var (games, metaData) = (await gameService.Get(pageNumber, pageSize));

        // -- Assert
        games.ToList().Should().HaveCount(3);
    }

    [Theory]
    [InlineData("burnout", 1)]
    [InlineData("developer", 3)]
    [InlineData("publishera", 2)]
    public async Task Should_FindCorrectAmountOfRecordsBasedOnSearchTerm(string searchTerm, int expectedTotalItemCount)
    {
        var mockedGameRepository = new Mock<IGameRepository>();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        mockedGameRepository.Setup(gRepo => gRepo.Get()).ReturnsAsync(_mockedGames.AsQueryable);
        int pageNumber = 1;
        int pageSize = 10;

        (IEnumerable<Game> games, PaginationMetadata metaData) = await gameService.Get(pageNumber, pageSize, searchTerm);

        metaData.TotalItemCount.Should().Be(expectedTotalItemCount);
    }

    [Fact]
    public async Task Should_FindCorrespondingGameToId()
    {
        var mockedGameRepository = new Mock<IGameRepository>();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        Guid gameId = Guid.NewGuid();
        mockedGameRepository.Setup(gRepo => gRepo.Get(gameId))
            .ReturnsAsync(new Game { Id = gameId, Name = "Call of Duty" });

        var game = await gameService.Get(gameId);

        game.Name.Should().BeEquivalentTo("Call of Duty");
    }

    [Fact]
    public async Task Should_ThrowKeyNotFoundException_When_NoGameMatchingAnIdIsFound()
    {
        var mockedGameRepository = new Mock<IGameRepository>();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        mockedGameRepository.Setup(gRepo => gRepo.Get(It.IsAny<Guid>()))
            .ThrowsAsync(new KeyNotFoundException());

        Func<Task> task = async () => await gameService.Get(Guid.NewGuid());

        await task.Should().ThrowAsync<KeyNotFoundException>();
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 3)]
    public async Task Should_ReturnALimitedCollectionMatchingThePageSize(int pageSize, int expectedCollectionSize)
    {
        var mockedGameRepository = new Mock<IGameRepository>();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        mockedGameRepository.Setup(gRepo => gRepo.Get()).ReturnsAsync(_mockedGames.AsQueryable);
        var pageNumber = 1;

        var (games, metaData) = (await gameService.Get(pageNumber, pageSize));

        games.ToList().Should().HaveCount(expectedCollectionSize);
    }

    [Fact]
    public async Task Should_HaveCorrectPaginationMetaData()
    {
        var mockedGameRepository = new Mock<IGameRepository>();
        IGameService gameService = new GameService(mockedGameRepository.Object);
        mockedGameRepository.Setup(gRepo => gRepo.Get()).ReturnsAsync(_mockedGames.AsQueryable);
        var pageNumber = 1;
        var pageSize = 2;

        var (games, metaData) = (await gameService.Get(pageNumber, pageSize));

        metaData.PageSize.Should().Be(2);
        metaData.CurrentPage.Should().Be(1);
        metaData.TotalItemCount.Should().Be(3);
        metaData.TotalPageCount.Should().Be(2);
    }
}
