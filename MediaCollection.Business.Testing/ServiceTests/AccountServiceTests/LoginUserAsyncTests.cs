using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MediaCollection.Business.Testing.ServiceTests.AccountServiceTests;

[ExcludeFromCodeCoverage]
public sealed class LoginUserAsyncTests : AccountServiceTestsBase
{
    [Fact]
    public async Task Should_ReturnASuccessResult()
    {
        // Arrange
        ApplicationUser user = new()
        {
            UserName = "ScroogeMacDuck",
            Email = "Scrooge@email.pl"
        };

        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);
        userManagerMock
            .Setup(x => x.IsEmailConfirmedAsync(user))
            .ReturnsAsync(true);

        Mock<SignInManager<ApplicationUser>> signInManagerMock = CreateSignInManagerMock(userManagerMock.Object);
        signInManagerMock
            .Setup(x => x.PasswordSignInAsync(user.UserName!, It.IsAny<string>(), It.IsAny<bool>(), false))
            .ReturnsAsync(SignInResult.Success);

        Mock<IJwtAuthorityManager> jwtManagerMock = new();
        jwtManagerMock
            .Setup(x => x.GenerateTokens(It.IsAny<string>(), It.IsAny<Claim[]>(), It.IsAny<DateTime>()))
            .Returns(new JwtAuthorityResult
            {
                AccessToken = "access-token",
                RefreshToken = new RefreshToken { TokenString = "refresh-token" }
            });

        IAccountService accountService = BuildAccountService(
            userManager: userManagerMock.Object,
            signInManager: signInManagerMock.Object,
            jwtAuthorityManager: jwtManagerMock.Object);

        LoginViewModel model = new()
        {
            Email = "Scrooge@email.pl",
            Password = "Password!234",
            RememberMe = true
        };

        // Act
        CustomResult<LogInResult> result = await accountService.LoginUserAsync(model);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();

        result.Value.UserName.Should().Be("ScroogeMacDuck");
        result.Value.AccessToken.Should().Be("access-token");
        result.Value.RefreshToken.Should().Be("refresh-token");
    }

    [Fact]
    public async Task Should_ReturnFailure_When_UserNotFound()
    {
        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser?)null);

        IAccountService accountService = BuildAccountService(userManager: userManagerMock.Object);

        CustomResult<LogInResult> result = await accountService.LoginUserAsync(new LoginViewModel());

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();

        result.Error.Should().BeEquivalentTo(CustomError.RecordNotFound("No user found."));
    }

    [Fact]
    public async Task Should_ReturnFailure_When_EmailNotConfirmed()
    {
        ApplicationUser user = new() { Email = "Scrooge@email.pl" };

        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);
        userManagerMock
            .Setup(x => x.IsEmailConfirmedAsync(user))
            .ReturnsAsync(false);

        IAccountService accountService = BuildAccountService(userManager: userManagerMock.Object);

        CustomResult<LogInResult> result = await accountService.LoginUserAsync(new LoginViewModel());

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();

        result.Error.Should().BeEquivalentTo(CustomError.UserNotConfirmed("User is not confirmed."));
    }

    [Fact]
    public async Task Should_ReturnFailure_When_SignInNotAllowed()
    {
        ApplicationUser user = new()
        {
            UserName = "ScroogeMacDuck",
            Email = "Scrooge@email.pl"
        };

        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);
        userManagerMock
            .Setup(x => x.IsEmailConfirmedAsync(user))
            .ReturnsAsync(true);

        Mock<SignInManager<ApplicationUser>> signInManagerMock = CreateSignInManagerMock(userManagerMock.Object);
        signInManagerMock
            .Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), false))
            .ReturnsAsync(SignInResult.NotAllowed);

        IAccountService accountService = BuildAccountService(
            userManagerMock.Object,
            signInManagerMock.Object
        );

        CustomResult<LogInResult> result = await accountService.LoginUserAsync(new LoginViewModel());

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();

        result.Error.Should().BeEquivalentTo(CustomError.Unauthorized("Something went wrong logging in."));
    }

    [Fact]
    public async Task Should_ReturnFailure_When_PasswordIsInvalid()
    {
        ApplicationUser user = new()
        {
            UserName = "ScroogeMacDuck",
            Email = "Scrooge@email.pl"
        };

        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);
        userManagerMock
            .Setup(x => x.IsEmailConfirmedAsync(user))
            .ReturnsAsync(true);

        Mock<SignInManager<ApplicationUser>> signInManagerMock = CreateSignInManagerMock(userManagerMock.Object);
        signInManagerMock
            .Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), false))
            .ReturnsAsync(SignInResult.Failed);

        IAccountService accountService = BuildAccountService(
            userManagerMock.Object,
            signInManagerMock.Object
        );

        CustomResult<LogInResult> result = await accountService.LoginUserAsync(new LoginViewModel());

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();

        result.Error.Should().BeEquivalentTo(CustomError.UnknownError("Something went wrong."));
    }
}
