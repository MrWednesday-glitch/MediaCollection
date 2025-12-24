namespace MediaCollection.Business.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

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
        IQueryable<Game> gameCollection = await _gameRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            searchTerm = searchTerm!.ToLower();

            gameCollection = gameCollection.Where(game => game.Name.ToLower().Contains(searchTerm) 
                                                           || game.Publisher.Name.ToLower().Contains(searchTerm) 
                                                           || game.Developer.Name.ToLower().Contains(searchTerm));
        }

        int totalItemCount = gameCollection.Count();
        PaginationMetadata paginationMetadata = new(totalItemCount, pageSize, pageNumber);

        List<Game> games = gameCollection
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (games, paginationMetadata);
    }

    public async Task<Game?> GetRandom()
    {
        IQueryable<Game> unfinishedGames = (await _gameRepository.Get())
            .Where(g => !g.Finished);
        int totalItemCount = unfinishedGames.Count();

        if (totalItemCount == 0)
        {
            return null;
        }

        Random random = new();
        int randomNumber = random.Next(0, totalItemCount);

        return unfinishedGames
            .Skip(randomNumber)
            .FirstOrDefault();
    }
}
