using MediaCollection.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Domain.Interfaces;

public interface IAccountService
{
    /// <summary>
    /// Creates a new user in the database.
    /// </summary>
    /// <param name="model">The data needed to create the user.</param>
    /// <returns>An object that includes whether it was succesful or not.</returns>
    Task<CustomResult<IdentityResult>> RegisterUserAsync(RegisterViewModel model);

    /// <summary>
    /// Logs the user into the application.
    /// </summary>
    /// <param name="model">The data needed to login.</param>
    /// <returns>Among other things the jwt bearer token.</returns>
    Task<CustomResult<LogInResult>> LoginUserAsync(LoginViewModel model);

    /// <summary>
    /// A method to retrieve the user information.
    /// </summary>
    /// <param name="email">The email as unique id to retrieve the information.</param>
    /// <returns>The user data.</returns>
    Task<CustomResult<ProfileViewModel>> GetUserProfileByEmailAsync(string email);
}
