using MediaCollection.Domain.Enums;

namespace MediaCollection.API.Controllers;

// TODO Unit test
// TODO Fix this
[ApiController]
[Route("games")]
public sealed class GameController : ControllerBase
{
    //private const int MaxPageSize = 20;
    //private readonly IGameService _gameService;

    //public GameController(IGameService gameService)
    //{
    //    ArgumentNullException.ThrowIfNull(gameService);

    //    _gameService = gameService;
    //}

    //[HttpGet("randomunfinished", Name = "GetRandomUnfinished")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public async Task<IActionResult> GetRandomUnfinishedAsync(CancellationToken cancellationToken = default)
    //{
    //    // TODO Get based on userid
    //    CustomResult<Game> randomGameResult = await _gameService.GetRandomAsync(cancellationToken);

    //    if (randomGameResult.IsFailure)
    //    {
    //        return StatusCode(204, new ErrorDetails(
    //            string.Empty,
    //            randomGameResult.Error.CustomErrorInformation.Message,
    //            204,
    //            string.Empty,
    //            HttpContext.Request.Path));
    //    }

    //    GameDTO gameDTO = Transform(randomGameResult.Value);

    //    return Ok(gameDTO);
    //}

    //[HttpGet(Name = "GetGames")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetGamesAsync(
    //    int pageNumber = 1,
    //    int pageSize = 10,
    //    string? searchTerm = "",
    //    CancellationToken cancellationToken = default) //TODO add filters
    //{
    //    if (pageSize > MaxPageSize)
    //    {
    //        pageSize = MaxPageSize;
    //    }

    //    // TODO Get based on userid
    //    var (gameResults, paginationMetadata) =
    //        await _gameService.GetAsync(pageNumber, pageSize, searchTerm, cancellationToken);

    //    if (gameResults.IsFailure)
    //    {
    //        return NotFound(new ErrorDetails(
    //            string.Empty,
    //            gameResults.Error.CustomErrorInformation.Message,
    //            404,
    //            string.Empty,
    //            HttpContext.Request.Path));
    //    }

    //    IEnumerable<GameDTO> gamesDTO = gameResults.Value.Select(g => Transform(g));

    //    Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

    //    return Ok(gamesDTO);
    //}

    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(500)]
    //public async Task<IActionResult> GetGameAsync(Guid id, CancellationToken cancellationToken = default)
    //{
    //    // TODO Get based on userid
    //    CustomResult<Game> gameResult = await _gameService.GetAsync(id, cancellationToken);

    //    if (gameResult.IsFailure)
    //    {
    //        return gameResult.Error.Code switch
    //        {
    //            ErrorCodes.RecordNotFound => NotFound(new ErrorDetails(
    //                string.Empty,
    //                gameResult.Error.CustomErrorInformation.Message,
    //                404,
    //                string.Empty,
    //                HttpContext.Request.Path)),
    //            ErrorCodes.UnknownError => BadRequest(new ErrorDetails(
    //                string.Empty,
    //                gameResult.Error.CustomErrorInformation.Message,
    //                400,
    //                string.Empty,
    //                HttpContext.Request.Path)),
    //            _ => StatusCode(500, new ErrorDetails(
    //                string.Empty,
    //                gameResult.Error.CustomErrorInformation.Message,
    //                500,
    //                string.Empty,
    //                HttpContext.Request.Path))
    //        };
    //    }

    //    GameDTO gameDTO = Transform(gameResult.Value);

    //    return Ok(gameDTO);
    //}

    ////private static GameDTO Transform(Game game)
    ////{
    ////    return new GameDTO
    ////    {
    ////        Id = game.Id,
    ////        Name = game.Name,
    ////        DeveloperName = game.Developer.Name,
    ////        PublisherName = game.Publisher.Name,
    ////        ReleaseDate = game.ReleaseDate.ToString("dd-MM-yyyy"),
    ////        Finished = game.Finished,
    ////        Owned = game.Owned,
    ////        OwnedOn = game.OwnedOn ?? "Unowned",
    ////        PictureUri = game.PictureUri,
    ////    };
    ////}

    //private static GameDTO Transform(UserGame userGame)
    //{
    //    return new GameDTO
    //    {
    //        Id = userGame.Game.Id,
    //        Name = userGame.Game.Name,
    //        DeveloperName = userGame.Game.Developer.Name,
    //        PublisherName = userGame.Game.Publisher.Name,
    //        ReleaseDate = userGame.Game.ReleaseDate.ToString("dd-MM-yyyy"),
    //        Finished = userGame.Finished,
    //        Owned = userGame.Owned,
    //        OwnedOn = userGame.OwnedOn?.ToString("dd-MM-yyyy") ?? "Unowned",
    //        PictureUri = userGame.Game.PictureUri,
    //    };
    //}
}
