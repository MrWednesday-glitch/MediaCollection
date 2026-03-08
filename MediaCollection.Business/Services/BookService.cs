namespace MediaCollection.Business.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        ArgumentNullException.ThrowIfNull(bookRepository);

        _bookRepository = bookRepository;
    }

    public async Task<(CustomResult<IEnumerable<Book>>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        IQueryable<Book> bookCollection = await _bookRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            searchTerm = searchTerm!.ToLower();

            bookCollection = bookCollection
                .TagWith("search")
                .Where(book => book.Name.ToLower().Contains(searchTerm)
                                || book.Publisher.Name.ToLower().Contains(searchTerm)
                                || book.Author.Name.ToLower().Contains(searchTerm));
        }

        int totalItemCount = bookCollection.Count();
        PaginationMetadata paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        List<Book> books = bookCollection
            .TagWith("get")
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (CustomResult<IEnumerable<Book>>.Success(books), paginationMetadata);
    }

    public async Task<CustomResult<Book>> Get(Guid id)
    {
        try
        {
            Book book = await _bookRepository.Get(id);

            return CustomResult<Book>.Success(book);
        }
        // TODO Unit test
        catch (RecordNotFoundException ex)
        {
            return CustomResult<Book>.Failure(CustomError.RecordNotFound(ex.Message));
        }
    }
}
