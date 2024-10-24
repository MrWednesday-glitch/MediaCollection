namespace MediaCollection.API.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private const int MaxPageSize = 20;
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IActionResult> GetBooks(int pageNumber = 1, int pageSize = 10, string? searchTerm = "")
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        var (books, paginationMetadata) = await _bookService.Get(pageNumber, pageSize, searchTerm);
        var booksDTO = books.Select(b => Transform(b));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(booksDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        try
        {
            var book = await _bookService.Get(id);
            var bookDTO = Transform(book);

            return Ok(bookDTO);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
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
