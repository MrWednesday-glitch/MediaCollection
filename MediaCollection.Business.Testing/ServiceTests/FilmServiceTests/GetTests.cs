namespace MediaCollection.Business.Testing.ServiceTests.FilmServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests
{
    private readonly Film[] _mockedFilms =
    [
        new Film { Id = 1, Name = "Alien" },
        new Film { Id = 2, Name = "Seven Samurai" },
        new Film { Id = 3, Name = "Gundam Hathaway" },
    ];

    [Fact]
    public async Task Should_ReturnTheCorrectAmountOfFilms()
    {
        // -- Arrange
        Mock<IFilmRepository> mockedFilmRepository = new();
        IFilmService filmService = new FilmService(mockedFilmRepository.Object);
        mockedFilmRepository.Setup(fRepo => fRepo.Get()).ReturnsAsync(_mockedFilms.AsQueryable());
        int pageNumber = 1;
        int pageSize = 10;

        // -- Act
        var (films, metadata) = await filmService.Get(pageNumber, pageSize);

        // -- Assert
        films.ToList().Should().HaveCount(3);
    }

    [Fact]
    public async Task Should_HaveCorrectPaginationMetaData()
    {
        Mock<IFilmRepository> mockedFilmRepository = new();
        IFilmService filmService = new FilmService(mockedFilmRepository.Object);
        mockedFilmRepository.Setup(fRepo => fRepo.Get()).ReturnsAsync(_mockedFilms.AsQueryable());
        int pageNumber = 1;
        int pageSize = 2;

        var (films, metadata) = await filmService.Get(pageNumber, pageSize);

        metadata.PageSize.Should().Be(2);
        metadata.CurrentPage.Should().Be(1);
        metadata.TotalItemCount.Should().Be(3);
        metadata.TotalPageCount.Should().Be(2);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 3)]
    public async Task Should_ReturnALimitedCollectionMatchingThePageSize(int pageSize, int expectedCollectionSize)
    {
        Mock<IFilmRepository> mockedFilmRepository = new();
        IFilmService filmService = new FilmService(mockedFilmRepository.Object);
        mockedFilmRepository.Setup(fRepo => fRepo.Get()).ReturnsAsync(_mockedFilms.AsQueryable());
        int pageNumber = 1;

        var (films, metadata) = await filmService.Get(pageNumber, pageSize);

        films.ToList().Should().HaveCount(expectedCollectionSize);
    }

    [Fact]
    public async Task Should_FindCorrectFilmToId()
    {
        Mock<IFilmRepository> mockedFilmRepository = new();
        IFilmService filmService = new FilmService(mockedFilmRepository.Object);
        mockedFilmRepository.Setup(fRepo => fRepo.Get(1))
            .ReturnsAsync(new Film { Id = 1, Name = "Alien" });

        Film film = await filmService.Get(1);

        film.Id.Should().Be(1);
        film.Name.Should().BeEquivalentTo("Alien");
    }

    [Fact]
    public async Task Should_ThrowKeyNotFoundException_When_NoFilmMatchingAnIdIsFound()
    {
        Mock<IFilmRepository> mockedFilmRepository = new();
        IFilmService filmService = new FilmService(mockedFilmRepository.Object);
        mockedFilmRepository.Setup(fRepo => fRepo.Get(It.IsAny<int>()))
            .ThrowsAsync(new KeyNotFoundException());

        Func<Task> getAction = async () => await filmService.Get(0);

        await getAction.Should().ThrowAsync<KeyNotFoundException>();
    }
}
