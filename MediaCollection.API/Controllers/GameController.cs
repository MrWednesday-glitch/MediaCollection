using Microsoft.AspNetCore.Http.HttpResults;

namespace MediaCollection.API.Controllers;

[ApiController]
[Route("games")]
public class GameController : ControllerBase
{
    private const int MaxPageSize = 20;
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        ArgumentNullException.ThrowIfNull(gameService);

        _gameService = gameService;
    }

    [HttpGet("randomunfinished", Name = "GetRandomUnfinished")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetRandomUnfinished()
    {
        CustomResult<Game> randomGameResult = await _gameService.GetRandom();

        if (randomGameResult.IsFailure)
        {
            return NoContent();
        }

        GameDTO gameDTO = Transform(randomGameResult.Value);

        return Ok(gameDTO);
    }

    [HttpGet(Name = "GetGames")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGames(int pageNumber = 1, int pageSize = 10, string? searchTerm = "") //TODO add filters
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (gameResults, paginationMetadata) = await _gameService.Get(pageNumber, pageSize, searchTerm);

        if (gameResults.IsFailure)
        {
            return NotFound();
        }

        IEnumerable<GameDTO> gamesDTO = gameResults.Value.Select(g => Transform(g));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(gamesDTO);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetGame(Guid id)
    {
        CustomResult<Game> gameResult = await _gameService.Get(id);

        if (gameResult.IsFailure)
        {
            return gameResult.Error.Code switch
            {
                ErrorCodes.RecordNotFound => NotFound(gameResult.Error.CustomErrorInformation),
                ErrorCodes.UnknownError => BadRequest(gameResult.Error.CustomErrorInformation),
                _ => StatusCode(500, gameResult.Error.CustomErrorInformation)
            };
        }

        GameDTO gameDTO = Transform(gameResult.Value);

        return Ok(gameDTO);
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
