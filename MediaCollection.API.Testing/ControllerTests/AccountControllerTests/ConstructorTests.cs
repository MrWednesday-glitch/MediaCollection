namespace MediaCollection.API.Testing.ControllerTests.AccountControllerTests;

public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_AccountServiceIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new AccountController(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("accountService");
    }
}
