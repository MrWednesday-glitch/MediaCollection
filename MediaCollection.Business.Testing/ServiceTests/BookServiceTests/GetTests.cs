namespace MediaCollection.Business.Testing.ServiceTests.BookServiceTests;

[ExcludeFromCodeCoverage]
public class GetTests
{
    private readonly Book[] _mockedBooks =
    [
        new Book { Id = 1, Name = "Huckleberry Finn" },
        new Book { Id = 2, Name = "Alice in Wonderland" },
        new Book { Id = 3, Name = "Kill all Normies" },
    ];

    [Fact]
    public async void SHould_ReturnCorrectAmountOfBooks()
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
        mockedBookRepository.Setup(bRepo => bRepo.Get(1))
            .ReturnsAsync(new Book { Id = 1, Name = "Feet of Clay" });

        Book book = await bookService.Get(1);

        book.Id.Should().Be(1);
        book.Name.Should().BeEquivalentTo("Feet of Clay");
    }

    [Fact]
    public async Task Should_ThrowKeyNotFoundException_When_TheGivenIdDoesNotMatchABook()
    {
        Mock<IBookRepository> mockedBookRepository = new Mock<IBookRepository>();
        IBookService bookService = new BookService(mockedBookRepository.Object);
        mockedBookRepository.Setup(bRepo => bRepo.Get(It.IsAny<int>()))
            .ThrowsAsync(new KeyNotFoundException());

        Func<Task> getAction = async () => await bookService.Get(1);

        await getAction.Should().ThrowAsync<KeyNotFoundException>();
    }
}
