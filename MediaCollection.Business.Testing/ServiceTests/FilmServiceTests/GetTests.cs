using System.Diagnostics.CodeAnalysis;

namespace MediaCollection.Business.Testing.ServiceTests.FilmServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests
{
    private readonly Film[] mockedFilms =
    [
        new Film        {            Id = 1,            Name = "Alien"        },
        new Film { Id = 2, Name = "Seven Samurai" },
        new Film { Id = 3, Name = "Gundam Hathaway" },
    ];

    [Fact]
    public async Task Should_ReturnTheCorrectAmountOfFilms()
    {
        // -- Arrange
        Mock<IFilmRepository> mockedFilmRepository = new();
        IFilmService filmService = new FilmService(mockedFilmRepository.Object);
        mockedFilmRepository.Setup(fRepo => fRepo.Get()).ReturnsAsync(mockedFilms.AsQueryable());
        int pageNumber = 1;
        int pageSize = 10;

        // -- Act
        var (films, metadata) = await filmService.Get(pageNumber, pageSize);

        // -- Assert
        films.ToList().Should().HaveCount(3);
    }
}
