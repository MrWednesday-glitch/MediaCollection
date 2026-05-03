namespace MediaCollection.Business.Testing.JwtAuthorityManagerTests;

[ExcludeFromCodeCoverage]
public class ConstructorTests
{
    [Fact]
    public void Should_ThrowArgumentNullException_If_JwtTokenConfigurationIsNull()
    {
        // -- Arrange

        // -- ACt
        Action testIncovation = () => _ = new JwtAuthorityManager(null!);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("jwtTokenConfiguration");
    }

    [Fact]
    public void Should_ThrowArgumentNullException_If_JwtTokenConfigurationSecretIsNull()
    {
        // -- Arrange
        JwtTokenConfiguration jwtTokenConfiguration = new()
        {
            AccessTokenExpiration = 67,
            RefreshTokenExpiration = 67_000
        };

        // -- ACt
        Action testIncovation = () => _ = new JwtAuthorityManager(jwtTokenConfiguration);

        // -- Assert
        testIncovation
            .Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("jwtTokenConfiguration.Secret");
    }
}
