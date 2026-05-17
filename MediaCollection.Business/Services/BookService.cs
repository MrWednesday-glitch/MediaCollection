using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Business.Services;

// TODO Fix unit tests
public sealed class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public BookService(IBookRepository bookRepository, UserManager<ApplicationUser> userManager)
    {
        ArgumentNullException.ThrowIfNull(bookRepository);
        ArgumentNullException.ThrowIfNull(userManager);

        _bookRepository = bookRepository;
        _userManager = userManager;
    }

    // TODO Change this to return CustomResult<IEnumerable<UserBook>>
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<(CustomResult<IEnumerable<Book>>, PaginationMetadata)> GetAsync(
        string userEmail,
        int pageNumber, 
        int pageSize, 
        string? searchTerm = "", 
        CancellationToken cancellationToken = default)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(userEmail);

        if (user is null)
        {
            return (CustomResult<IEnumerable<Book>>.Failure(CustomError.Unauthorized("No user found.")), new PaginationMetadata(0,1,1));
        }

        IQueryable<Book> bookCollection = (await _bookRepository.GetAsync())
            .Where(b => b.UserBooks.Any(ub => ub.UserId == user.Id));

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
