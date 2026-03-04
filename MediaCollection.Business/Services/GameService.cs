namespace MediaCollection.Business.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
    }

    public async Task<CustomResult<Game>> Get(Guid id)
    {
        try
        {
            Game game = await _gameRepository.Get(id);

            return CustomResult<Game>.Success(game);
        }
        catch (RecordNotFoundException ex)
        {
            return CustomResult<Game>.Failure(CustomError.RecordNotFound(ex.Message));
        }
    }

    public async Task<(CustomResult<IEnumerable<Game>>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
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

        return (CustomResult<IEnumerable<Game>>.Success(games), paginationMetadata);
    }

    public async Task<CustomResult<Game>> GetRandom()
    {
        IQueryable<Game> unfinishedGames = (await _gameRepository.Get())
            .Where(g => !g.Finished);
        int totalItemCount = unfinishedGames.Count();

        if (totalItemCount == 0)
        {
            string message = "No unfinished game to be found.";
            
            return CustomResult<Game>.Failure(CustomError.RecordNotFound(message));
        }

        Random random = new();
        int randomNumber = random.Next(0, totalItemCount);

        Game randomGame = unfinishedGames
            .Skip(randomNumber)
            .First();

        return CustomResult<Game>.Success(randomGame);
    }
}
