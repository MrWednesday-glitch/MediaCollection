using Microsoft.AspNetCore.Identity;

namespace MediaCollection.API.Testing.ControllerTests.AccountControllerTests;

[ExcludeFromCodeCoverage]
public sealed class RegisterTests : AccountControllerTestBase
{
    [Fact]
    public async Task Should_RegisterNewUserCorrectly()
    {
        // -- Arrange
        RegisterViewModel registerViewModel = new()
        {
            Email = "scrooge@duck.org",
            FirstName = "Scrooge",
            LastName = "McDuck",
            Password = "Password!234",
            ConfirmPassword = "Password!234"
        };
        IdentityResult identityResult = IdentityResult.Success;
        Mock<IAccountService> mockedAccountService = new();
        mockedAccountService
            .Setup(x => x.RegisterUserAsync(registerViewModel))
            .ReturnsAsync(CustomResult<IdentityResult>.Success(identityResult));
        AccountController controller = BuildAccountController(mockedAccountService.Object);

        // -- Act
        IActionResult result = await controller.RegisterAsync(registerViewModel);

        // -- Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ObjectResult>();

        ObjectResult objectResult = result.As<ObjectResult>();
        objectResult.StatusCode.Should().Be(201);

        objectResult.Value.Should().BeEquivalentTo(IdentityResult.Success);
    }

    [Fact]
    public async Task Should_ReturnBadRequest_WhenModelStateIsInvalid()
    {
        // -- Arrange
        RegisterViewModel registerViewModel = new();
        Mock<IAccountService> mockedAccountService = new();
        AccountController controller = BuildAccountController(mockedAccountService.Object);
        controller.ModelState.AddModelError("Email", "Required");

        // -- Act
        IActionResult result = await controller.RegisterAsync(registerViewModel);

        // -- Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<BadRequestObjectResult>();

        BadRequestObjectResult badRequest = result.As<BadRequestObjectResult>();
        badRequest.StatusCode.Should().Be(400);

        mockedAccountService.Verify(x => x.LoginUserAsync(It.IsAny<LoginViewModel>()), Times.Never);
    }

    [Fact]
    public async Task Should_ReturnBadRequest_WhenSomethingGoesWrong()
    {
        // -- Arrange
        RegisterViewModel registerViewModel = new()
        {
            Email = "scrooge@duck.org",
            FirstName = "Scrooge",
            LastName = "McDuck",
            Password = "Password!234",
            ConfirmPassword = "Password!234"
        };
        Mock<IAccountService> mockedAccountService = new();
        mockedAccountService
            .Setup(x => x.RegisterUserAsync(registerViewModel))
            .ReturnsAsync(CustomResult<IdentityResult>.Failure(CustomError.UnknownError("Cannot create user.")));
        AccountController controller = BuildAccountController(mockedAccountService.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // -- Act
        IActionResult result = await controller.RegisterAsync(registerViewModel);

        // -- Assert
        result
            .Should().BeOfType<BadRequestObjectResult>()
            .Which.Value
            .Should().BeEquivalentTo(new ErrorDetails(
                Instance: string.Empty,
                Detail: string.Empty,
                Status: 400,
                Title: "Cannot create user.",
                Type: string.Empty));
    }
}
