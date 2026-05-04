namespace MediaCollection.Business.Services;

public sealed class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        ArgumentNullException.ThrowIfNull(bookRepository);

        _bookRepository = bookRepository;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<(CustomResult<IEnumerable<Book>>, PaginationMetadata)> GetAsync(
        int pageNumber, 
        int pageSize, 
        string? searchTerm = "", 
        CancellationToken cancellationToken = default)
    {
        IQueryable<Book> bookCollection = await _bookRepository.GetAsync();

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
        PaginationMetadata paginationMetadata = new(totalItemCount, pageSize, pageNumber);

        List<Book> books = bookCollection
            .TagWith("get")
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (CustomResult<IEnumerable<Book>>.Success(books), paginationMetadata);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<CustomResult<Book>> Get(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            Book book = await _bookRepository.GetAsync(id, cancellationToken);

            return CustomResult<Book>.Success(book);
        }
        catch (RecordNotFoundException ex)
        {
            return CustomResult<Book>.Failure(CustomError.RecordNotFound(ex.Message));
        }
    }
}
