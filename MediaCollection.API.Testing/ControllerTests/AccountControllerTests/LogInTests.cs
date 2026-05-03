namespace MediaCollection.API.Testing.ControllerTests.AccountControllerTests;

[ExcludeFromCodeCoverage]
public class LoginTests : AccountControllerTestBase
{
    [Fact]
    public async Task Should_LoginCorrectly()
    {
        // -- Arrange
        LoginViewModel loginViewModel = new()
        {
            Email = "achievementhunter@dead.org",
            Password = "Password!234",
            RememberMe = true,
        };
        LogInResult logInResult = new()
        {
            AccessToken = "I am allowed to be here.",
            RefreshToken = "1234567890",
            Role = "User",
            UserName = "Homer",
        };
        Mock<IAccountService> mockedAccountService = new();
        mockedAccountService
            .Setup(x => x.LoginUserAsync(loginViewModel))
            .Returns(Task.FromResult(CustomResult<LogInResult>.Success(logInResult)));
        AccountController accountController = BuildAccountController(mockedAccountService.Object);

        // -- Act
        IActionResult result = await accountController.LoginAsync(loginViewModel);

        // -- Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();

        var okResult = result.As<OkObjectResult>();
        okResult.StatusCode.Should().Be(200);

        okResult.Value.Should().BeEquivalentTo(new LogInResult
        {
            UserName = "Homer",
            Role = "User",
            AccessToken = "I am allowed to be here.",
            RefreshToken = "1234567890"
        });
    }
}
