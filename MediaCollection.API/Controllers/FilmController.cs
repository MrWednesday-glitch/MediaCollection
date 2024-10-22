namespace MediaCollection.API.Controllers;

[ApiController]
[Route("films")]
public class FilmController : ControllerBase
{
    private const int MaxPageSize = 20;
    private readonly IFilmService _filmService;

    public FilmController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    [HttpGet(Name = "GetFilms")]
    public async Task<IActionResult> GetFilms(int pageNumber = 1, int pageSize = 10, string? searchTerm = "")
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (films, paginationMetadata) = await _filmService.Get(pageNumber, pageSize, searchTerm);
        var filmsDTO = films.Select(f => Transform(f));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(filmsDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        try
        {
            var film = await _filmService.Get(id);
            var filmDTO = Transform(film);

            return Ok(filmDTO);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private FilmDTO Transform(Film film)
    {
        return new FilmDTO
        {
            Id = film.Id,
            Name = film.Name,
            DirectorName = film.Director.Name,
            PublisherName = film.Publisher.Name,
            ReleaseDate = film.ReleaseDate.ToString("dd-MM-yyyy"),
        };
    }
}
