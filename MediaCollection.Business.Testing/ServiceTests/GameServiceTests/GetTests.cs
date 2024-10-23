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
        },
        new Game
        {
            Id = Guid.NewGuid(),
            Name = "Atelier Ryza",
        },
        new Game
        {
            Id = Guid.NewGuid(),
            Name = "Burnout",
        },
    ];

    // TODO Figure out how to test this
    //[Fact]
    //public void Should_ThrowArgumentNullException_When_TheRepositoryIsNull()
    //{
    //    Mock<IGameRepository>? mockedGameRepository = null;
    //    //IGameService gameService = new GameService(mockedGameRepository.Object);

    //    var invocation = () => new GameService(mockedGameRepository.Object);

    //    invocation.Should().Throw<ArgumentNullException>().WithMessage("gameRepository");
    //}

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
