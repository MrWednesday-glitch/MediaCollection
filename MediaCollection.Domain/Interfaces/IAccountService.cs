using MediaCollection.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Domain.Interfaces;

// TODO Write summaries
public interface IAccountService
{
    Task<CustomResult<IdentityResult>> RegisterUserAsync(RegisterViewModel model);

    Task<CustomResult<LogInResult>> LoginUserAsync(LoginViewModel model);

    Task<CustomResult<ProfileViewModel>> GetUserProfileByEmailAsync(string email);
}
