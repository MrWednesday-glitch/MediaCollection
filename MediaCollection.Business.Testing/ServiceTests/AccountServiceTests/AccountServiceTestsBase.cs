using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Business.Testing.ServiceTests.AccountServiceTests;

[ExcludeFromCodeCoverage]
public class AccountServiceTestsBase
{
    internal static IAccountService BuildAccountService(
        UserManager<ApplicationUser>? userManager = null,
        SignInManager<ApplicationUser>? signInManager = null,
        RoleManager<ApplicationRole>? roleManager = null,
        DateTimeWrapper? dateTimeWrapper = null,
        IJwtAuthorityService? jwtAuthorityManager = null)
    {
        IAccountService accountService = new AccountService(
            userManager ?? CreateUserManagerMock().Object,
            signInManager ?? CreateSignInManagerMock().Object,
            roleManager ?? CreateRoleManagerMock().Object,
            dateTimeWrapper ?? new DateTimeWrapper(),
            jwtAuthorityManager ?? Mock.Of<IJwtAuthorityService>());

        return accountService;
    }

    internal static Mock<UserManager<ApplicationUser>> CreateUserManagerMock()
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

    internal static Mock<SignInManager<ApplicationUser>> CreateSignInManagerMock(UserManager<ApplicationUser>? userManager = null)
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

    internal static Mock<RoleManager<ApplicationRole>> CreateRoleManagerMock()
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
