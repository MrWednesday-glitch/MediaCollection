using MediaCollection.API.DTOModels;
using MediaCollection.Domain.Entities;
using MediaCollection.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

    [HttpGet(Name = "GetGames")]
    public async Task<IActionResult> GetGames(int pageNumber = 1, int pageSize = 10, string? searchTerm = "") //TODO add filters
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (games, paginationMetadata) = await _gameService.Get(pageNumber, pageSize, searchTerm);
        var gamesDTO = games.Select(g => Transform(g)); // TODO Add a transform here

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(gamesDTO);
    }

    private GameDTO Transform(Game game)
    {
        return new GameDTO
        {
            Id = game.Id,
            Name = game.Name,
            DeveloperName = game.Developer.Name,
            PublisherName = game.Publisher.Name,
            ReleaseDate = game.ReleaseDate.ToShortDateString(), // TODO Check if this is what I want
            Finished = game.Finished,
            Owned = game.Owned,
            OwnedOn = game.OwnedOn ?? "Unowned"
        };
    }
}
