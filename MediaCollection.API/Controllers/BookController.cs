using MediaCollection.API.DTOModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace MediaCollection.API.Controllers;

// TODO Unit test
[ApiController]
[Route("books")]
[Authorize]
public sealed class BookController : ControllerBase
{
    private const int MaxPageSize = 20;
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        ArgumentNullException.ThrowIfNull(bookService);

        _bookService = bookService;
    }

    [HttpGet(Name = "GetBooks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBooksAsync(int pageNumber = 1, int pageSize = 10, string? searchTerm = "", CancellationToken cancellationToken = default)
    {
        if (pageSize > MaxPageSize)
        {
            pageSize = MaxPageSize;
        }

        string? userEmail = User.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrEmpty(userEmail))
        {
            return NotFound(new ErrorDetails(
                string.Empty,
                "User not found",
                404,
                string.Empty,
                HttpContext.Request.Path));
        }

        var (bookResults, paginationMetadata) = await _bookService.GetAsync(userEmail, pageNumber, pageSize, searchTerm, cancellationToken);

        if (bookResults.IsFailure)
        {
            return NotFound(new ErrorDetails(
                string.Empty,
                bookResults.Error.CustomErrorInformation.Message,
                404,
                string.Empty,
                HttpContext.Request.Path));
        }

        IEnumerable<BookDTO> booksDTO = bookResults.Value.Select(b => Transform(b));

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(booksDTO);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBookAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            CustomResult<Book> bookResult = await _bookService.Get(id, cancellationToken);

            if (bookResult.IsFailure)
            {
                return NotFound(new ErrorDetails(
                    string.Empty,
                    bookResult.Error.CustomErrorInformation.Message,
                    404,
                    string.Empty,
                    HttpContext.Request.Path));
            }

            BookDTO bookDTO = Transform(bookResult.Value);

            return Ok(bookDTO);
        }
        catch (Exception ex)
        {
            // TODO Fix this
            return BadRequest(ex.Message);
        }
    }

    private static BookDTO Transform(Book book)
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
