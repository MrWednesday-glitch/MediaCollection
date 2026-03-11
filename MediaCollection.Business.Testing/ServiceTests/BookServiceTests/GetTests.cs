namespace MediaCollection.Business.Testing.ServiceTests.BookServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests
{
    private readonly Book[] _mockedBooks =
    [
        new Book
        {
            Id = Guid.NewGuid(),
            Name = "Huckleberry Finn",
            Author = new Author
            {
                Name = "AuthorA",
            },
            Publisher = new Publisher
            {
                Name = "PublisherA",
            },
        },
        new Book
        {
            Id = Guid.NewGuid(),
            Name = "Alice in Wonderland",
            Author = new Author
            {
                Name = "AuthorB"
            },
            Publisher = new Publisher
            {
                Name = "PublisherA"
            },
        },
        new Book
        {
            Id = Guid.NewGuid(),
            Name = "Kill all Normies",
            Author = new Author
            {
                Name = "AuthorC"
            },
            Publisher = new Publisher
            {
                Name = "PublisherB"
            },
        },
    ];

    [Fact]
    public async Task Should_ReturnCorrectAmountOfBooks()
    {
        // -- Arrange
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.GetAsync()).ReturnsAsync(_mockedBooks.AsQueryable());
        int pageNumber = 1;
        int pageSize = 10;

        // -- Act
        var (booksResult, metadata) = await bookService.GetAsync(pageNumber, pageSize);

        // -- Assert
        booksResult.Value.ToList().Should().HaveCount(3);
    }

    [Fact]
    public async Task Should_HaveCorrectPaginationMetaData()
    {
        // -- Arrange
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.GetAsync()).ReturnsAsync(_mockedBooks.AsQueryable());
        int pageNumber = 1;
        int pageSize = 2;

        // -- Act
        var (books, metadata) = await bookService.GetAsync(pageNumber, pageSize);

        // -- Assert
        metadata.PageSize.Should().Be(2);
        metadata.CurrentPage.Should().Be(1);
        metadata.TotalItemCount.Should().Be(3);
        metadata.TotalPageCount.Should().Be(2);
    }

    [Theory]
    [InlineData("finn", 1)]
    [InlineData("author", 3)]
    [InlineData("publishera", 2)]
    public async Task Should_FindCorrectAmountOfRecordsBasedOnSearchTerm(string searchTerm, int expectedTotalItemCount)
    {
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.GetAsync()).ReturnsAsync(_mockedBooks.AsQueryable());
        int pageNumber = 1;
        int pageSize = 10;

        (CustomResult<IEnumerable<Book>> booksResult, PaginationMetadata metaData) = await bookService.GetAsync(pageNumber, pageSize, searchTerm);

        metaData.TotalItemCount.Should().Be(expectedTotalItemCount);
    }

    [Fact]
    public async Task Should_FindCorrectBookMatchingId()
    {
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        Guid bookId = Guid.NewGuid();
        mockedBookRepository.Setup(bRepo => bRepo.GetAsync(bookId))
            .ReturnsAsync(new Book { Id = bookId, Name = "Feet of Clay" });

        CustomResult<Book> bookResult = await bookService.Get(bookId);

        bookResult.Value.Id.Should().Be(bookId);
        bookResult.Value.Name.Should().BeEquivalentTo("Feet of Clay");
    }

    [Fact]
    public async Task Should_ThrowKeyNotFoundException_When_TheGivenIdDoesNotMatchABook()
    {
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.GetAsync(It.IsAny<Guid>()))
            .ThrowsAsync(new KeyNotFoundException());

        Func<Task> getAction = async () => await bookService.Get(Guid.NewGuid());

        await getAction.Should().ThrowAsync<KeyNotFoundException>();
    }
}
