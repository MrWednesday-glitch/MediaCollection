using MediaCollection.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Interfaces;

// TODO Write summaries
public interface IAccountService
{
    Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);

    Task<CustomResult<LogInResult>> LoginUserAsync(LoginViewModel model);

    Task<ProfileViewModel> GetUserProfileByEmailAsync(string email);
}

// TODO Move this to the domain
// TODO SUmmaries
public record LogInResult()
{
    public string UserName { get; init; }

    public string Role { get; init; }

    public string AccessToken { get; init; }

    public string RefreshToken { get; init; }
}
