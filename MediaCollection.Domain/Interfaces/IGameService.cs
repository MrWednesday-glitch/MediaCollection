namespace MediaCollection.Domain.Interfaces;

public interface IGameService
{
    /// <summary>
    /// Adds logic to a call to the database for all the game entitites.
    /// Among other things it applies the logic for pagination.
    /// </summary>
    /// <param name="pageNumber">A specific set of entities.</param>
    /// <param name="pageSize">The amount of entities that will be in the given selection.</param>
    /// <param name="searchTerm">A search term used to go through the database and grab a selection of game entities.</param>
    /// <returns>A task that contains the selection of game entities.</returns>
    Task<(CustomResult<IEnumerable<Game>>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "");

    /// <summary>
    /// Adds logic to a single game entity that was retrieved from the database.
    /// </summary>
    /// <param name="id">The id of the game entity that is required from the database.</param>
    /// <returns>A game entity.</returns>
    Task<CustomResult<Game>> Get(Guid id);

    /// <summary>
    /// Logic to select a random unfinished game from the database.
    /// </summary>
    /// <returns>A random game, or null if no unfinished games exist in the database.</returns>
    Task<CustomResult<Game>> GetRandom();
}
