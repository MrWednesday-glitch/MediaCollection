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

    Task<SignInResult> LoginUserAsync(LoginViewModel model);

    Task<ProfileViewModel> GetUserProfileByEmailAsync(string email);
}
