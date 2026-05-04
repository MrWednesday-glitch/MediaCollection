using MediaCollection.Domain.Models;
using System.Security.Claims;

namespace MediaCollection.Domain.Interfaces;

public interface IJwtAuthorityService
{
    /// <summary>
    /// A method used to generate a JWT Token
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="claims"></param>
    /// <param name="now"></param>
    /// <returns>A refresh token and an access token.</returns>
    JwtAuthorityResult GenerateTokens(string userName, Claim[] claims, DateTime now);
}
