namespace MediaCollection.API.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private const int MaxPageSize = 20;
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        ArgumentNullException.ThrowIfNull(bookService);

        _bookService = bookService;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IActionResult> GetBooks(int pageNumber = 1, int pageSize = 10, string? searchTerm = "")
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (bookResults, paginationMetadata) = await _bookService.Get(pageNumber, pageSize, searchTerm);

        if (bookResults.IsFailure)
        {
            return NotFound();
        }

        IEnumerable<BookDTO> booksDTO = bookResults.Value.Select(b => Transform(b));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(booksDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        try
        {
            CustomResult<Book> bookResult = await _bookService.Get(id);

            if (bookResult.IsFailure)
            {
                return NotFound(bookResult.Error.Message);
            }

            BookDTO bookDTO = Transform(bookResult.Value);

            return Ok(bookDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private BookDTO Transform(Book book)
    {
        return new BookDTO
        {
            Id = book.Id,
            Name = book.Name,
            AuthorName = book.Author.Name,
            PublisherName = book.Publisher.Name,
            ReleaseDate = book.ReleaseDate.ToString("dd-MM-yyyy"),
            PictureUri = book.PictureUri,
        };
    }
}
