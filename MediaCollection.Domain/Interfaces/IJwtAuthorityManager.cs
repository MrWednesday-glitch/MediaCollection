using MediaCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MediaCollection.Domain.Interfaces;

public interface IJwtAuthorityManager
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
