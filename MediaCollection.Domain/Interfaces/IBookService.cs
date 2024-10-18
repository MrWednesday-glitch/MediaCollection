namespace MediaCollection.Domain.Interfaces;

public interface IBookService
{
    //TODO Write summary
    Task<(IEnumerable<Book>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "");

    // TODO Write Summary
    Task<Book> Get(int id);
}
