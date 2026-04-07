namespace MediaCollection.Business.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        ArgumentNullException.ThrowIfNull(gameRepository);

        _gameRepository = gameRepository;
    }

    public async Task<CustomResult<Game>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            Game game = await _gameRepository.GetAsync(id, cancellationToken);

            return CustomResult<Game>.Success(game);
        }
        // TODO Unit test
        catch (RecordNotFoundException ex)
        {
            return CustomResult<Game>.Failure(CustomError.RecordNotFound(ex.Message));
        }
    }

    public async Task<(CustomResult<IEnumerable<Game>>, PaginationMetadata)> GetAsync(
        int pageNumber, 
        int pageSize, 
        string? searchTerm = "",
        CancellationToken cancellationToken = default)
    {
        IQueryable<Game> gameCollection = await _gameRepository.GetAsync();

        if (!searchTerm.IsNullOrEmpty())
        {
            searchTerm = searchTerm!.ToLower();

            gameCollection = gameCollection
                .TagWith("search")
                .Where(game => game.Name.ToLower().Contains(searchTerm)
                                || game.Publisher.Name.ToLower().Contains(searchTerm)
                                || game.Developer.Name.ToLower().Contains(searchTerm));
        }

        int totalItemCount = gameCollection.Count();
        PaginationMetadata paginationMetadata = new(totalItemCount, pageSize, pageNumber);

        List<Game> games = gameCollection
            .TagWith("get")
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (CustomResult<IEnumerable<Game>>.Success(games), paginationMetadata);
    }

    // TODO Add userId to the parameter list
    // TODO Fix unit tests
    public async Task<CustomResult<Game>> GetRandomAsync(CancellationToken cancellationToken = default)
    {
        IQueryable<Game> unfinishedGames = (await _gameRepository.GetAsync())
            .TagWith("random")
            .Where(g => g.UserGames.Any(ug => /* ug.UserId == userId && */ !ug.Finished))
            //.Where(g => !g.Finished)
            ;
        int totalItemCount = unfinishedGames.Count();

        if (totalItemCount == 0)
        {
            string message = "No unfinished game to be found.";

            return CustomResult<Game>.Failure(CustomError.RecordNotFound(message));
        }

        Random random = new();
        int randomNumber = random.Next(0, totalItemCount);

        Game randomGame = unfinishedGames
            .TagWith("random")
            .Skip(randomNumber)
            .First();

        return CustomResult<Game>.Success(randomGame);
    }
}
