using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Business.Services;

// TODO fix unit tests
/// <summary>
/// The implementation of the <see cref="IGameService"/>.
/// </summary>
public sealed class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    public GameService(IGameRepository gameRepository, UserManager<ApplicationUser> userManager)
    {
        ArgumentNullException.ThrowIfNull(gameRepository);
        ArgumentNullException.ThrowIfNull(userManager);

        _gameRepository = gameRepository;
        _userManager = userManager;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
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

    // TODO Change this to return CustomResult<IEnumerable<UserGame>>
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<(CustomResult<IEnumerable<Game>>, PaginationMetadata)> GetAsync(
        string userEmail,
        int pageNumber, 
        int pageSize, 
        string? searchTerm = "",
        CancellationToken cancellationToken = default)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(userEmail);

        if (user is null)
        {
            return (CustomResult<IEnumerable<Game>>.Failure(CustomError.Unauthorized("No user found.")), new PaginationMetadata(0, 1, 1));
        }

        IQueryable<Game> gameCollection = (await _gameRepository.GetAsync())
            .Where(g => g.UserGames.Any(ug => ug.UserId == user.Id));

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
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
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
