namespace MediaCollection.API.Controllers;

[ApiController]
[Route("films")]
public class FilmController : ControllerBase
{
    private const int MaxPageSize = 20;
    private readonly IFilmService _filmService;

    public FilmController(IFilmService filmService)
    {
        ArgumentNullException.ThrowIfNull(filmService);

        _filmService = filmService;
    }

    [HttpGet(Name = "GetFilms")]
    public async Task<IActionResult> GetFilms(int pageNumber = 1, int pageSize = 10, string? searchTerm = "")
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (filmsResult, paginationMetadata) = await _filmService.Get(pageNumber, pageSize, searchTerm);

        if (filmsResult.IsFailure)
        {
            return NotFound();
        }

        IEnumerable<FilmDTO> filmsDTO = filmsResult.Value.Select(f => Transform(f));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(filmsDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Getfilm(Guid id)
    {
        try
        {
            CustomResult<Film> filmResult = await _filmService.Get(id);

            if (filmResult.IsFailure)
            {
                return NotFound(filmResult.Error.CustomErrorInformation);
            }

            FilmDTO filmDTO = Transform(filmResult.Value);

            return Ok(filmDTO);
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
            PictureUri = film.PictureUri,
        };
    }
}
