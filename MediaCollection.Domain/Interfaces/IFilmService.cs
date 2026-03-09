namespace MediaCollection.Domain.Interfaces;

public interface IFilmService
{
    /// <summary>
    /// Retrieves a part of all the film records from the database.
    /// </summary>
    /// <param name="pageNumber">Which selection of film records are retrieved.</param>
    /// <param name="pageSize">The amount of film records retrieved.</param>
    /// <param name="searchTerm">A term that ensures only matching records are retrieved.</param>
    /// <returns>A task holding a collection of films and matching metadata.</returns>
    Task<(CustomResult<IEnumerable<Film>>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "", CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a record matching the id.
    /// </summary>
    /// <param name="id">The id of the wanted record.</param>
    /// <returns>A task with a film value.</returns>
    Task<CustomResult<Film>> Get(Guid id, CancellationToken cancellationToken = default);
}
