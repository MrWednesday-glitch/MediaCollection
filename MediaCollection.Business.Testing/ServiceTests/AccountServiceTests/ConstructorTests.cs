using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Business.Testing.ServiceTests.AccountServiceTests;

[ExcludeFromCodeCoverage]
public class ConstructorTests
{
    [Fact]
    public void Should_ThrowAnArgumentNullException_When_UserManagerIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new AccountService(
            null!,
            null!,
            null!,
            null!,
            null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("userManager");
    }

    [Fact]
    public void Should_ThrowAnArgumentNullException_When_SignInManagerIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new AccountService(
            CreateUserManagerMock().Object,
            null!,
            null!,
            null!,
            null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("signInManager");
    }

    [Fact]
    public void Should_ThrowAnArgumentNullException_When_RoleManagerIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new AccountService(
            CreateUserManagerMock().Object,
            CreateSignInManagerMock().Object,
            null!,
            null!,
            null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("roleManager");
    }

    [Fact]
    public void Should_ThrowAnArgumentNullException_When_DateTimeWrapperIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new AccountService(
            CreateUserManagerMock().Object,
            CreateSignInManagerMock().Object,
            CreateRoleManagerMock().Object,
            null!,
            null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("dateTimeWrapper");
    }

    [Fact]
    public void Should_ThrowAnArgumentNullException_When_JwtAuthorityManagerIsNull()
    {
        // -- Arrange

        // -- Act
        Action testIncovation = () => _ = new AccountService(
            CreateUserManagerMock().Object,
            CreateSignInManagerMock().Object,
            CreateRoleManagerMock().Object,
            Mock.Of<DateTimeWrapper>(),
            null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("jwtAuthorityManager");
    }

    private static Mock<UserManager<ApplicationUser>> CreateUserManagerMock()
    {
        Mock<IUserStore<ApplicationUser>> userStore = new();
        Mock<UserManager<ApplicationUser>> userManagerMock = new(
            userStore.Object,
            null!,
            null!,
            Array.Empty<IUserValidator<ApplicationUser>>(),
            Array.Empty<IPasswordValidator<ApplicationUser>>(),
            null!,
            null!,
            null!,
            null!
        );

        return userManagerMock;
    }

    private static Mock<SignInManager<ApplicationUser>> CreateSignInManagerMock(UserManager<ApplicationUser>? userManager = null)
    {
        userManager ??= CreateUserManagerMock().Object;

        Mock<IHttpContextAccessor> contextAccessor = new();
        Mock<IUserClaimsPrincipalFactory<ApplicationUser>> claimsFactory = new();

        Mock<SignInManager<ApplicationUser>> signInManagerMock = new(
            userManager,
            contextAccessor.Object,
            claimsFactory.Object,
            null!,
            null!,
            null!,
            null!
        );

        return signInManagerMock;
    }

    private static Mock<RoleManager<ApplicationRole>> CreateRoleManagerMock()
    {
        Mock<IRoleStore<ApplicationRole>> roleStore = new();

        Mock<RoleManager<ApplicationRole>> roleManagerMock = new Mock<RoleManager<ApplicationRole>>(
            roleStore.Object,
            Array.Empty<IRoleValidator<ApplicationRole>>(),
            null!,
            null!,
            null!
        );

        return roleManagerMock;
    }
}
