namespace MediaCollection.Business.Testing.ServiceTests.BookServiceTests;

public class ConstructorTests
{
    [Fact]
    public void SHould_ThrowAnArgumentNullException_When_BookRepositoryIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new BookService(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("bookRepository");
    }
}
