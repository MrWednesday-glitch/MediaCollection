namespace MediaCollection.Business.Services;

// TODO Write unit tests
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

    public async Task<(IEnumerable<Book>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        var bookCollection = await _bookRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            // TODO add logic to search through books
        }

        var totalItemCount = bookCollection.Count();
        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        var books = bookCollection
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (books, paginationMetadata);
    }

    public async Task<Book> Get(int id)
    {
        return await _bookRepository.Get(id);
    }
}
