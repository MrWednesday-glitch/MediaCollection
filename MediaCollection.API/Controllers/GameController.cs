using MediaCollection.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediaCollection.API.Controllers;

[ApiController]
[Route("games")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet(Name = "GetGames")]
    public IActionResult GetGames()
    {
        return Ok(_gameService.Get());
    }

}
