using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MediaCollection.Business.Services;

/// <summary>
/// The implementation of the <see cref="IJwtAuthorityService"/>.
/// </summary>
public sealed class JwtAuthorityService : IJwtAuthorityService
{
    private readonly ConcurrentDictionary<string, RefreshToken> _usersRefreshTokens;
    private readonly JwtTokenConfiguration _jwtTokenConfiguration;
    private readonly byte[] _secret;

    /// <summary>
    /// Initialized the constructor.
    /// </summary>
    public JwtAuthorityService(JwtTokenConfiguration jwtTokenConfiguration)
    {
        ArgumentNullException.ThrowIfNull(jwtTokenConfiguration);
        ArgumentNullException.ThrowIfNull(jwtTokenConfiguration.Secret);

        _jwtTokenConfiguration = jwtTokenConfiguration;
        _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
        _secret = Encoding.ASCII.GetBytes(jwtTokenConfiguration.Secret);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public JwtAuthorityResult GenerateTokens(string userName, Claim[] claims, DateTime now)
    {
        bool shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?
            .FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Aud)?
            .Value);
        JwtSecurityToken jwtToken = new(
            _jwtTokenConfiguration.Issuer,
            shouldAddAudienceClaim ? _jwtTokenConfiguration.Audience : string.Empty,
            claims,
            expires: now.AddMinutes(_jwtTokenConfiguration.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));
        string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        RefreshToken refreshToken = new()
        {
            UserName = userName,
            TokenString = GenerateRefreshTokenString(),
            ExpireAt = now.AddMinutes(_jwtTokenConfiguration.RefreshTokenExpiration)
        };
        _usersRefreshTokens.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);

        return new JwtAuthorityResult
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    /// <summary>
    /// Uses a random number generator to create a refresh token.
    /// </summary>
    /// <returns>The refresh token.</returns>
    private static string GenerateRefreshTokenString()
    {
        byte[] randomNumber = new byte[32];
        using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}
