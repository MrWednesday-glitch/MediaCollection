namespace MediaCollection.Domain.Interfaces;

public interface IBookService
{
    /// <summary>
    /// Retrieves a part of all the book records from the database.
    /// </summary>
    /// <param name="pageNumber">Which selection of book records are retrieved.</param>
    /// <param name="pageSize">The amount of book records retrieved.</param>
    /// <param name="searchTerm">A term that ensures only matching records are retrieved.</param>
    /// <returns>A task holding a collection of book and matching metadata.</returns>
    Task<(CustomResult<IEnumerable<Book>>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "");

    /// <summary>
    /// Retrieves a record matching the id.
    /// </summary>
    /// <param name="id">The id of the wanted record.</param>
    /// <returns>A task with a book value.</returns>
    Task<CustomResult<Book>> Get(Guid id);
}
