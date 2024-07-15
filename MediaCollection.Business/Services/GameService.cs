using MediaCollection.Data;
using MediaCollection.Domain.Entities;
using MediaCollection.Domain.Interfaces;

namespace MediaCollection.Business.Services;
public class GameService : IGameService
{
    private readonly MockDatabase _mockDatabase;

    public GameService(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    public IEnumerable<Game> Get()
    {
        return _mockDatabase.Get();
    }

    public Game Get(int id)
    {
        return _mockDatabase.Get()
            .FirstOrDefault(x => x.Id == id) ?? throw new Exception("No game found");
    }
}
