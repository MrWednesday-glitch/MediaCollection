using MediaCollection.Domain.Entities;
using MediaCollection.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace MediaCollection.Business.Services;
public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public Game Get(int id)
    {
        throw new NotImplementedException();
        //return _mockDatabase.Get().FirstOrDefault(x => x.Id == id) ?? throw new Exception("No game found");
    }

    public async Task<(IEnumerable<Game>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        var gameCollection = await _gameRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            // TODO add logic to search through games
        }

        var totalItemCount = gameCollection.Count();
        var paginationMetadata = new PaginationMetadata(pageNumber, pageSize, totalItemCount);

        var games = gameCollection
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (games, paginationMetadata);
    }
}
