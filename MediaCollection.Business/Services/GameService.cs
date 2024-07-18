using MediaCollection.Data;
using MediaCollection.Domain.Entities;
using MediaCollection.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace MediaCollection.Business.Services;
public class GameService : IGameService
{
    private readonly MockDatabase _mockDatabase;

    public GameService(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public Game Get(int id)
    {
        return _mockDatabase.Get()
            .FirstOrDefault(x => x.Id == id) ?? throw new Exception("No game found");
    }

    public async Task<(IEnumerable<Game>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {


        if (!searchTerm.IsNullOrEmpty())
        {
            // TODO add logic to search through games
        }

        throw new NotImplementedException();
    }
}
