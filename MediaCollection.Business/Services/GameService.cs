using MediaCollection.Domain.Entities;
using MediaCollection.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace MediaCollection.Business.Services;

//TODO Write unit tests
public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> Get(int id)
    {
        return await _gameRepository.Get(id);
    }

    public async Task<(IEnumerable<Game>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        var gameCollection = await _gameRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            // TODO add logic to search through games
        }

        var totalItemCount = gameCollection.Count();
        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        var games = gameCollection
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (games, paginationMetadata);
    }
}
