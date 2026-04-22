namespace MediaCollection.Business.Testing.ServiceTests.AccountServiceTests;

[ExcludeFromCodeCoverage]
public class ConstructorTests : AccountServiceTestsBase
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
}
