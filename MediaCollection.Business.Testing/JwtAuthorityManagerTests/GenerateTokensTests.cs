using System.Security.Claims;

namespace MediaCollection.Business.Testing.JwtAuthorityManagerTests;

[ExcludeFromCodeCoverage]
public class GenerateTokensTests
{
    [Fact]
    public void Should_FollowTheHappyPath()
    {
        // -- Arrange
        IJwtAuthorityManager jwtAuthorityManager = BuildJwtAuthorityManager(new JwtTokenConfiguration()
        {
            Audience = "Steve",
            Issuer = "Bob",
            Secret = "00000000-0000-0000-0000-000000000001",
            AccessTokenExpiration = 10,
            RefreshTokenExpiration = 1_440
        });
        string userName = "Joel";
        Claim[] claims = [new Claim("userName", userName)];
        DateTime dateTime = new(2026, 5, 3);

        // -- Act
        JwtAuthorityResult result = jwtAuthorityManager.GenerateTokens(userName, claims, dateTime);

        // -- Assert
        result.Should().NotBeNull();
        result.AccessToken.Should().NotBeNullOrEmpty();
        result.RefreshToken.TokenString.Should().NotBeNullOrEmpty();
        result.RefreshToken.UserName.Should().BeEquivalentTo(userName);
        result.RefreshToken.ExpireAt.Should().Be(new DateTime(2026, 5, 4));
    }

    private static IJwtAuthorityManager BuildJwtAuthorityManager(JwtTokenConfiguration? jwtTokenConfiguration = null)
    {
        IJwtAuthorityManager jwtAuthorityManager = new JwtAuthorityManager(jwtTokenConfiguration ?? new JwtTokenConfiguration()
        {
            Audience = "Steve",
            Issuer = "Bob",
            Secret = "00000000-0000-0000-0000-000000000001",
            AccessTokenExpiration = 67,
            RefreshTokenExpiration = 67_000
        });

        return jwtAuthorityManager;
    }
}
