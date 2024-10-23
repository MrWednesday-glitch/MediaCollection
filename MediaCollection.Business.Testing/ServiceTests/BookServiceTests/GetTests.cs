namespace MediaCollection.Business.Testing.ServiceTests.BookServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests
{
    private readonly Book[] _mockedBooks =
    [
        new Book { Id = Guid.NewGuid(), Name = "Huckleberry Finn" },
        new Book { Id = Guid.NewGuid(), Name = "Alice in Wonderland" },
        new Book { Id = Guid.NewGuid(), Name = "Kill all Normies" },
    ];

    [Fact]
    public async Task SHould_ReturnCorrectAmountOfBooks()
    {
        // -- Arrange
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.Get()).ReturnsAsync(_mockedBooks.AsQueryable());
        int pageNumber = 1;
        int pageSize = 10;

        // -- Act
        var (books, metadata) = await bookService.Get(pageNumber, pageSize);

        // -- Assert
        books.ToList().Should().HaveCount(3);
    }

    [Fact]
    public async Task Should_HaveCorrectPaginationMetaData()
    {
        // -- Arrange
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.Get()).ReturnsAsync(_mockedBooks.AsQueryable());
        int pageNumber = 1;
        int pageSize = 2;

        // -- Act
        var (books, metadata) = await bookService.Get(pageNumber, pageSize);

        // -- Assert
        metadata.PageSize.Should().Be(2);
        metadata.CurrentPage.Should().Be(1);
        metadata.TotalItemCount.Should().Be(3);
        metadata.TotalPageCount.Should().Be(2);
    }

    [Fact]
    public async Task SHould_FindCorrectBookMatchingId()
    {
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        Guid bookId = Guid.NewGuid();
        mockedBookRepository.Setup(bRepo => bRepo.Get(bookId))
            .ReturnsAsync(new Book { Id = bookId, Name = "Feet of Clay" });

        Book book = await bookService.Get(bookId);

        book.Id.Should().Be(bookId);
        book.Name.Should().BeEquivalentTo("Feet of Clay");
    }

    [Fact]
    public async Task Should_ThrowKeyNotFoundException_When_TheGivenIdDoesNotMatchABook()
    {
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.Get(It.IsAny<Guid>()))
            .ThrowsAsync(new KeyNotFoundException());

        Func<Task> getAction = async () => await bookService.Get(Guid.NewGuid());

        await getAction.Should().ThrowAsync<KeyNotFoundException>();
    }
}
