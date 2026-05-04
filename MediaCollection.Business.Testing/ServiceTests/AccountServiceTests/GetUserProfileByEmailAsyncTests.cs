using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Business.Testing.ServiceTests.AccountServiceTests;

[ExcludeFromCodeCoverage]
public sealed class GetUserProfileByEmailAsyncTests : AccountServiceTestsBase
{

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Should_ReturnFailureResult_If_EmailIsNullOrEmpty(string? email)
    {
        // -- Arrange
        IAccountService accountService = BuildAccountService();

        // -- Act
        CustomResult<ProfileViewModel> result = await accountService.GetUserProfileByEmailAsync(email!);

        // -- Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().BeEquivalentTo(CustomError.UnknownError("Email cannot be null or empty."));

    }

    [Fact]
    public async Task Should_ReturnFailureResult_If_ApplicationUserIsNull()
    {
        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        string email = "ikbestaniet@email.com";
        userManagerMock
            .Setup(x => x.FindByEmailAsync(email))
            .ReturnsAsync((ApplicationUser?)null!);
        IAccountService accountService = BuildAccountService(userManager: userManagerMock.Object);

        CustomResult<ProfileViewModel> result = await accountService.GetUserProfileByEmailAsync(email);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().BeEquivalentTo(CustomError.RecordNotFound($"No user found for {email}."));
    }

    [Fact]
    public async Task Should_ReturnSuccessResult()
    {
        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        string email = "test@email.com";
        DateTime createdOn = new DateTime(2026, 04, 17);
        userManagerMock
            .Setup(x => x.FindByEmailAsync(email))
            .ReturnsAsync(new ApplicationUser()
            {
                Email = email,
                UserName = "TestUserName",
                FirstName = "Test",
                LastName = "Burger",
                CreatedOn = createdOn
            });
        IAccountService accountService = BuildAccountService(userManager: userManagerMock.Object);

        CustomResult<ProfileViewModel> result = await accountService.GetUserProfileByEmailAsync(email);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.FirstName.Should().BeEquivalentTo("Test");
        result.Value.UserName.Should().BeEquivalentTo("TestUserName");
        result.Value.LastName.Should().BeEquivalentTo("Burger");
        result.Value.Email.Should().BeEquivalentTo(email);
        result.Value.CreatedOn.Should().Be(createdOn);
    }

    [Fact]
    public async Task Should_ReturnSuccessResultWithEmptyValues()
    {
        Mock<UserManager<ApplicationUser>> userManagerMock = CreateUserManagerMock();
        string email = "test@email.com";
        DateTime createdOn = new(2026, 04, 17);
        userManagerMock
            .Setup(x => x.FindByEmailAsync(email))
            .ReturnsAsync(new ApplicationUser()
            {
                Email = null,
                UserName = null,
                FirstName = "Test",
                LastName = "Burger",
                CreatedOn = createdOn
            });
        IAccountService accountService = BuildAccountService(userManager: userManagerMock.Object);

        CustomResult<ProfileViewModel> result = await accountService.GetUserProfileByEmailAsync(email);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.FirstName.Should().BeEquivalentTo("Test");
        result.Value.UserName.Should().BeEquivalentTo("");
        result.Value.LastName.Should().BeEquivalentTo("Burger");
        result.Value.Email.Should().BeEquivalentTo("");
        result.Value.CreatedOn.Should().Be(createdOn);
    }
}
