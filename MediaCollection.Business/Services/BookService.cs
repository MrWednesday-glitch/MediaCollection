namespace MediaCollection.Business.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

    public async Task<(IEnumerable<Book>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        IQueryable<Book> bookCollection = await _bookRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            searchTerm = searchTerm.ToLower();

            bookCollection = bookCollection.Where(book => book.Name.ToLower().Contains(searchTerm)
                                                           || book.Publisher.Name.ToLower().Contains(searchTerm)
                                                           || book.Author.Name.ToLower().Contains(searchTerm));
        }

        int totalItemCount = bookCollection.Count();
        PaginationMetadata paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        List<Book> books = bookCollection
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (books, paginationMetadata);
    }

    public async Task<Book> Get(Guid id)
    {
        return await _bookRepository.Get(id);
    }
}
