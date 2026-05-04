using System.Security.Claims;

namespace MediaCollection.API.Testing.ControllerTests.AccountControllerTests;

[ExcludeFromCodeCoverage]
public class ShowProfileTests : AccountControllerTestBase
{
    [Fact]
    public async Task Should_ReturnUnauthorized_When_EmailClaimMissing()
    {
        // Arrange
        AccountController controller = BuildAccountController();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity())
            }
        };

        // Act
        IActionResult result = await controller.ShowProfileAsync();

        // Assert
        result.Should().BeOfType<UnauthorizedObjectResult>();
        UnauthorizedObjectResult? unauthorized = result as UnauthorizedObjectResult;
        unauthorized!.Value.Should().BeEquivalentTo(new
        {
            Message = "User not authenticated."
        });
    }

    [Fact]
    public async Task Should_ReturnProfileViewModel_When_Successful()
    {
        // Arrange
        string email = "john@test.com";

        ProfileViewModel expectedProfile = new()
        {
            Email = email,
            UserName = email,
            FirstName = "John",
            LastName = "Doe",
            CreatedOn = DateTime.UtcNow.AddDays(-10),
            LastLoggedIn = DateTime.UtcNow.AddDays(-1)
        };

        Mock<IAccountService> serviceMock = new();
        serviceMock
            .Setup(s => s.GetUserProfileByEmailAsync(email))
            .ReturnsAsync(CustomResult<ProfileViewModel>.Success(expectedProfile));

        AccountController controller = BuildAccountController(serviceMock.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = CreateHttpContextWithEmail(email)
        };

        // Act
        IActionResult result = await controller.ShowProfileAsync();

        // Assert
        result.Should().BeOfType<OkObjectResult>();

        ProfileViewModel returnedProfile = (result as OkObjectResult)!.Value as ProfileViewModel;

        returnedProfile.Should().NotBeNull();
        returnedProfile.Should().BeEquivalentTo(expectedProfile);
    }

    [Fact]
    public async Task Should_ReturnBadRequest_When_UnknownError()
    {
        // Arrange
        string email = "john@test.com";
        string errorMessage = "Cannot create user.";

        CustomError error = CustomError.UnknownError(errorMessage);

        Mock<IAccountService> serviceMock = new();
        serviceMock
            .Setup(s => s.GetUserProfileByEmailAsync(email))
            .ReturnsAsync(CustomResult<ProfileViewModel>.Failure(error));

        AccountController controller = BuildAccountController(serviceMock.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = CreateHttpContextWithEmail(email)
        };

        // Act
        IActionResult result = await controller.ShowProfileAsync();

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();

        ErrorDetails errorDetails = (result as BadRequestObjectResult)!.Value as ErrorDetails;

        errorDetails.Should().NotBeNull();
        errorDetails.Status.Should().Be(400);
        errorDetails.Title.Should().BeEquivalentTo(errorMessage);
    }

    [Fact]
    public async Task Should_ReturnNotFound_When_UserDoesNotExist()
    {
        // Arrange
        string email = "missing@test.com";
        string errorMessage = "User not found.";

        CustomError error = CustomError.RecordNotFound(errorMessage);

        Mock<IAccountService> serviceMock = new();
        serviceMock
            .Setup(s => s.GetUserProfileByEmailAsync(email))
            .ReturnsAsync(CustomResult<ProfileViewModel>.Failure(error));

        AccountController controller = BuildAccountController(serviceMock.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = CreateHttpContextWithEmail(email)
        };

        // Act
        IActionResult result = await controller.ShowProfileAsync();

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();

        var errorDetails = (result as NotFoundObjectResult)!.Value as ErrorDetails;

        errorDetails.Should().NotBeNull();
        errorDetails!.Status.Should().Be(404);
        errorDetails.Title.Should().BeEquivalentTo(errorMessage);
    }

    private static HttpContext CreateHttpContextWithEmail(string email)
    {
        ClaimsIdentity identity = new(
        [
            new Claim(ClaimTypes.Email, email)
        ], "TestAuth");

        return new DefaultHttpContext
        {
            User = new ClaimsPrincipal(identity)
        };
    }
}
