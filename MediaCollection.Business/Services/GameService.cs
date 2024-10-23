namespace MediaCollection.Business.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    // TODO unittest argument null repository is null
    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
    }

    public async Task<Game> Get(Guid id)
    {
        return await _gameRepository.Get(id);
    }

    public async Task<(IEnumerable<Game>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        var gameCollection = await _gameRepository.Get();

        //TODO Write unit tests if searchterm is filled
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
