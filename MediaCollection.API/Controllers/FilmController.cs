namespace MediaCollection.API.Controllers;

// TODO Unit test
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFilmsAsync(int pageNumber = 1, int pageSize = 10, string? searchTerm = "", CancellationToken cancellationToken = default)
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (filmsResult, paginationMetadata) = await _filmService.GetAsync(pageNumber, pageSize, searchTerm, cancellationToken);

        if (filmsResult.IsFailure)
        {
            return NotFound(new ErrorDetails(
                string.Empty,
                filmsResult.Error.CustomErrorInformation.Message,
                404,
                string.Empty,
                HttpContext.Request.Path));
        }

        IEnumerable<FilmDTO> filmsDTO = filmsResult.Value.Select(f => Transform(f));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(filmsDTO);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetfilmAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            CustomResult<Film> filmResult = await _filmService.GetAsync(id, cancellationToken);

            if (filmResult.IsFailure)
            {
                return NotFound(new ErrorDetails(
                    string.Empty,
                    filmResult.Error.CustomErrorInformation.Message,
                    404,
                    string.Empty,
                    HttpContext.Request.Path));
            }

            FilmDTO filmDTO = Transform(filmResult.Value);

            return Ok(filmDTO);
        }
        catch (Exception ex)
        {
            // TODO Fix this
            return BadRequest(ex.Message);
        }
    }

    private static FilmDTO Transform(Film film)
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
