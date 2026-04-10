using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MediaCollection.Business.Services;

// TODO Write summaries
// TODO Write unit tests
public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly DateTimeWrapper _dateTimeWrapper;
    private readonly IJwtAuthorityManager _jwtAuthorityManager;

    public AccountService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager,
        DateTimeWrapper dateTimeWrapper,
        IJwtAuthorityManager jwtAuthorityManager)
    {
        ArgumentNullException.ThrowIfNull(userManager);
        ArgumentNullException.ThrowIfNull(signInManager);
        ArgumentNullException.ThrowIfNull(roleManager);
        ArgumentNullException.ThrowIfNull(dateTimeWrapper);
        ArgumentNullException.ThrowIfNull(jwtAuthorityManager);

        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _dateTimeWrapper = dateTimeWrapper;
        _jwtAuthorityManager = jwtAuthorityManager;
    }

    public async Task<ProfileViewModel> GetUserProfileByEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        }

        ApplicationUser user = await _userManager.FindByEmailAsync(email) ?? throw new ArgumentException("User not found.", nameof(email));

        return new ProfileViewModel
        {
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedOn = user.CreatedOn,
        };
    }

    public async Task<CustomResult<LogInResult>> LoginUserAsync(LoginViewModel model)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            //return SignInResult.Failed;
            return CustomResult<LogInResult>.Failure(CustomError.RecordNotFound("No user found."));
        }

        if (!await _userManager.IsEmailConfirmedAsync(user))
        {
            //return SignInResult.NotAllowed;
            return CustomResult<LogInResult>.Failure(CustomError.UserNotConfirmed("User is not confirmed."));
        }

        SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName!, model.Password, model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            Claim[]? claims =
            [
                new Claim("Username", user.UserName),
                new Claim("Role", "user"),
                new Claim("Email", user.Email)
            ];

            JwtAuthorityResult jwtResult = _jwtAuthorityManager.GenerateTokens(user.UserName, claims, _dateTimeWrapper.UtcNow);

            return CustomResult<LogInResult>.Success(new LogInResult
            {
                Role = "User",
                UserName = user.UserName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        return CustomResult<LogInResult>.Failure(CustomError.UnknownError("Something went wrong."));
    }

    public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model)
    {
        ApplicationUser user = new()
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName ?? string.Empty,
            CreatedOn = _dateTimeWrapper.UtcNow,
        };

        IdentityResult result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return result;
        }

        // Assign "User" role by default
        // TODO Ensure that roles excist

        // Ensure role exists
        // TODO REplace this and seed an user and admin role and connect it to the raven@email.me
        //if (!await _roleManager.RoleExistsAsync("User"))
        //{
        //    await _roleManager.CreateAsync(new ApplicationRole() { Name = "User", NormalizedName = "USER" });
        //}


        IdentityResult roleAssignResult = await _userManager.AddToRoleAsync(user, "User");

        if (!roleAssignResult.Succeeded)
        {
            // Handle error - optionally return this failure instead
            // or log the issue and continue
            return roleAssignResult;
        }

        return result;
    }
}

// TODO Move this to its own file
// TODO Test
// TODO Summaries
// TODO Explain this in the readme
public class DateTimeWrapper
{
    private readonly DateTime? _dateTime;

    public DateTimeWrapper()
    {
        _dateTime = null;
    }

    public DateTimeWrapper(DateTime fixedDateTime)
    {
        _dateTime = fixedDateTime;
    }

    public DateTime Now
    {
        get
        {
            return _dateTime ?? DateTime.Now;
        }
    }

    public DateTime UtcNow
    {
        get
        {
            return _dateTime ?? DateTime.UtcNow;
        }
    }
}

//// TODO Move this to the domain
//// TODO SUmmaries
//public record LogInResult()
//{
//    public string UserName { get; init; }

//    public string Role { get; init; }

//    public string AccessToken { get; init; }

//    public string RefreshToken { get; init; }
//}
