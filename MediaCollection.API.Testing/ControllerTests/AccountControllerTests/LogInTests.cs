namespace MediaCollection.API.Testing.ControllerTests.AccountControllerTests;

[ExcludeFromCodeCoverage]
public sealed class LoginTests : AccountControllerTestBase
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
            .ReturnsAsync(CustomResult<LogInResult>.Success(logInResult));
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

    [Fact]
    public async Task Should_ReturnBadRequest_WhenModelStateIsInvalid()
    {
        // -- Arrange
        Mock<IAccountService> mockedAccountService = new();
        AccountController controller = BuildAccountController(mockedAccountService.Object);

        controller.ModelState.AddModelError("Email", "Required");

        LoginViewModel model = new();

        // -- Act
        IActionResult result = await controller.LoginAsync(model);

        // -- Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<BadRequestObjectResult>();

        BadRequestObjectResult badRequest = result.As<BadRequestObjectResult>();
        badRequest.StatusCode.Should().Be(400);

        mockedAccountService.Verify(x => x.LoginUserAsync(It.IsAny<LoginViewModel>()), Times.Never);
    }

    [Fact]
    public async Task Should_ReturnNotFound_WhenUserDoesNotExist()
    {
        // -- Arrange
        LoginViewModel model = new()
        {
            Email = "missing@test.com",
            Password = "Password123!"
        };

        Mock<IAccountService> mockedAccountService = new();
        mockedAccountService
            .Setup(x => x.LoginUserAsync(model))
            .ReturnsAsync(CustomResult<LogInResult>.Failure(
                CustomError.RecordNotFound("No user found.")));

        AccountController controller = BuildAccountController(mockedAccountService.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // -- Act
        IActionResult result = await controller.LoginAsync(model);

        // -- Assert
        result
            .Should().BeOfType<NotFoundObjectResult>()
            .Which.Value
            .Should().BeEquivalentTo(new ErrorDetails(
                Instance: string.Empty,
                Detail: string.Empty,
                Status: 404,
                Title: "No user found.",
                Type: string.Empty));
    }

    [Fact]
    public async Task Should_ReturnBadRequest_WhenUserNotConfirmed()
    {
        // -- Arrange
        LoginViewModel model = new()
        {
            Email = "unconfirmed@test.com",
            Password = "Password123!"
        };

        Mock<IAccountService> mockedAccountService = new();
        mockedAccountService
            .Setup(x => x.LoginUserAsync(model))
            .ReturnsAsync(CustomResult<LogInResult>.Failure(
                CustomError.UserNotConfirmed("User is not confirmed.")));

        AccountController controller = BuildAccountController(mockedAccountService.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // -- Act
        IActionResult result = await controller.LoginAsync(model);

        // -- Assert
        result
            .Should().BeOfType<BadRequestObjectResult>()
            .Which.Value
            .Should().BeEquivalentTo(new ErrorDetails(
                Instance: string.Empty,
                Detail: string.Empty,
                Status: 400,
                Title: "User is not confirmed.",
                Type: string.Empty));
    }

    [Fact]
    public async Task Should_ReturnUnauthorized_WhenUserPasswordIsNotCorrect()
    {
        // -- Arrange
        LoginViewModel model = new()
        {
            Email = "wrongpassword@test.com",
            Password = "Password123!"
        };

        Mock<IAccountService> mockedAccountService = new();
        mockedAccountService
            .Setup(x => x.LoginUserAsync(model))
            .ReturnsAsync(CustomResult<LogInResult>.Failure(
                CustomError.Unauthorized("Something went wrong logging in.")));

        AccountController controller = BuildAccountController(mockedAccountService.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // -- Act
        IActionResult result = await controller.LoginAsync(model);

        // -- Assert
        result
            .Should().BeOfType<UnauthorizedObjectResult>()
            .Which.Value
            .Should().BeEquivalentTo(new ErrorDetails(
                Instance: string.Empty,
                Detail: string.Empty,
                Status: 401,
                Title: "Something went wrong logging in.",
                Type: string.Empty));
    }

    [Fact]
    public async Task Should_Return500_WhenSomethingUnknownGoesWrong()
    {
        // -- Arrange
        LoginViewModel model = new()
        {
            Email = "unknownerror@test.com",
            Password = "Password123!"
        };

        Mock<IAccountService> mockedAccountService = new();
        mockedAccountService
            .Setup(x => x.LoginUserAsync(model))
            .ReturnsAsync(CustomResult<LogInResult>.Failure(
                CustomError.UnknownError("Something went wrong.")));

        AccountController controller = BuildAccountController(mockedAccountService.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // -- Act
        IActionResult result = await controller.LoginAsync(model);

        // -- Assert
        result
            .Should().BeOfType<ObjectResult>()
            .Which.Value
            .Should().BeEquivalentTo(new ErrorDetails(
                Instance: string.Empty,
                Detail: string.Empty,
                Status: 500,
                Title: "Something went wrong.",
                Type: string.Empty));
    }
}
