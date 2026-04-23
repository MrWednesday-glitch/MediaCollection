using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Business.Testing.ServiceTests.AccountServiceTests;

[ExcludeFromCodeCoverage]
public sealed class RegisterUserAsyncTests : AccountServiceTestsBase
{
    [Fact]
    public async Task Should_RegisterUserCorrectly()
    {
        // -- Arrange
        RegisterViewModel model = new()
        {
            FirstName = "Scrooge",
            LastName = "MacDuck",
            ConfirmPassword = "Password!234",
            Password = "Password!234",
            Email = "Scrooge@email.pl",
        };
        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        Mock<RoleManager<ApplicationRole>> roleManagerMock = CreateRoleManagerMock();
        roleManagerMock
            .Setup(x => x.RoleExistsAsync("User"))
            .ReturnsAsync(true);
        userManagerMock
            .Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"))
            .ReturnsAsync(IdentityResult.Success);
        DateTime fixedDateTime = new(2026, 4, 23);
        DateTimeWrapper wrapper = new(fixedDateTime);
        IAccountService accountService = BuildAccountService(
            userManager: userManagerMock.Object,
            roleManager: roleManagerMock.Object,
            dateTimeWrapper: wrapper);

        // -- Act
        CustomResult<IdentityResult> result = await accountService.RegisterUserAsync(model);

        // -- Assert
        result.IsSuccess.Should().BeTrue();
        userManagerMock.Verify(
            x => x.CreateAsync(It.Is<ApplicationUser>(u =>
                u.Email == model.Email &&
                u.UserName == model.Email &&
                u.FirstName == model.FirstName &&
                u.LastName == model.LastName
            ),
            model.Password),
            Times.Once);

        userManagerMock.Verify(
            x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"),
            Times.Once);
    }

    [Fact]
    public async Task Should_ReturnFailure_When_RegisteringGoesWrong()
    {
        // -- Arrange
        RegisterViewModel model = new()
        {
            FirstName = "Scrooge",
            LastName = "MacDuck",
            ConfirmPassword = "Password!234",
            Password = "Password!234",
            Email = "Scrooge@email.pl",
        };
        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed());
        DateTime fixedDateTime = new(2026, 4, 23);
        DateTimeWrapper wrapper = new(fixedDateTime);
        IAccountService accountService = BuildAccountService(
            userManager: userManagerMock.Object,
            dateTimeWrapper: wrapper);

        // -- Act
        CustomResult<IdentityResult> result = await accountService.RegisterUserAsync(model);

        // -- Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();

        result.Error.Should().BeEquivalentTo(CustomError.UnknownError("Cannot create user."));
    }

    [Fact]
    public async Task Should_ReturnFailure_When_AddingARoleGoesWrong()
    {
        // -- Arrange
        RegisterViewModel model = new()
        {
            FirstName = "Scrooge",
            LastName = "MacDuck",
            ConfirmPassword = "Password!234",
            Password = "Password!234",
            Email = "Scrooge@email.pl",
        };
        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        userManagerMock
            .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        Mock<RoleManager<ApplicationRole>> roleManagerMock = CreateRoleManagerMock();
        roleManagerMock
            .Setup(x => x.RoleExistsAsync("User"))
            .ReturnsAsync(true);
        userManagerMock
            .Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), "User"))
            .ReturnsAsync(IdentityResult.Failed());
        DateTime fixedDateTime = new(2026, 4, 23);
        DateTimeWrapper wrapper = new(fixedDateTime);
        IAccountService accountService = BuildAccountService(
            userManager: userManagerMock.Object,
            roleManager: roleManagerMock.Object,
            dateTimeWrapper: wrapper);

        // -- Act
        CustomResult<IdentityResult> result = await accountService.RegisterUserAsync(model);

        // -- Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();

        result.Error.Should().BeEquivalentTo(CustomError.UnknownError("Something went wrong with user creation."));
    }
}
