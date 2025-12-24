namespace MediaCollection.API.Controllers;

[ApiController]
[Route("games")]
public class GameController : ControllerBase
{
    private const int MaxPageSize = 20;
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("randomunfinished", Name = "GetRandomUnfinished")]
    public async Task<IActionResult> GetRandomUnfinished()
    {
        Game? randomGame = await _gameService.GetRandom();

        if (randomGame is null) 
        {
            // TODO Make something of an errorfactory that returns a standard set of json key=values per non standard result.
            return NoContent();
        }

        GameDTO gameDTO = Transform(randomGame);

        return Ok(gameDTO);
    }

    [HttpGet(Name = "GetGames")]
    public async Task<IActionResult> GetGames(int pageNumber = 1, int pageSize = 10, string? searchTerm = "") //TODO add filters
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (games, paginationMetadata) = await _gameService.Get(pageNumber, pageSize, searchTerm);
        IEnumerable<GameDTO> gamesDTO = games.Select(g => Transform(g));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(gamesDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(Guid id)
    {
        try
        {
            Game game = await _gameService.Get(id);
            GameDTO gameDTO = Transform(game);

            return Ok(gameDTO);
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

    private GameDTO Transform(Game game)
    {
        return new GameDTO
        {
            Id = game.Id,
            Name = game.Name,
            DeveloperName = game.Developer.Name,
            PublisherName = game.Publisher.Name,
            ReleaseDate = game.ReleaseDate.ToString("dd-MM-yyyy"),
            Finished = game.Finished,
            Owned = game.Owned,
            OwnedOn = game.OwnedOn ?? "Unowned",
            PictureUri = game.PictureUri,
        };
    }
}
