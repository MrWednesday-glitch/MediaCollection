using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MediaCollection.Business.Services;

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

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<CustomResult<ProfileViewModel>> GetUserProfileByEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return CustomResult<ProfileViewModel>.Failure(CustomError.UnknownError("Email cannot be null or empty."));
        }

        ApplicationUser? user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return CustomResult<ProfileViewModel>.Failure(CustomError.RecordNotFound($"No user found for {email}."));
        }

        return CustomResult<ProfileViewModel>.Success(new ProfileViewModel
        {
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedOn = user.CreatedOn,
        });
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
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

        if (result.IsNotAllowed)
        {
            return CustomResult<LogInResult>.Failure(CustomError.Unauthorized("Something went wrong logging in."));
        }

        if (!result.Succeeded)
        {
            return CustomResult<LogInResult>.Failure(CustomError.UnknownError("Something went wrong."));
        }

        Claim[]? claims =
        [
            new Claim("Username", user.UserName!),
            new Claim("Role", "user"),
            new Claim("Email", user.Email!)
        ];

        JwtAuthorityResult jwtResult = _jwtAuthorityManager.GenerateTokens(user.UserName!, claims, _dateTimeWrapper.UtcNow);

        return CustomResult<LogInResult>.Success(new LogInResult
        {
            Role = "User",
            UserName = user.UserName!,
            AccessToken = jwtResult.AccessToken,
            RefreshToken = jwtResult.RefreshToken.TokenString
        });
    }

    // TODO Write unit tests
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<CustomResult<IdentityResult>> RegisterUserAsync(RegisterViewModel model)
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
            // TODO Check
            return CustomResult<IdentityResult>.Failure(CustomError.UnknownError("Cannot create user."));
        }

        // Assign "User" role by default
        // TODO Get rid of this eventually when I find a better place for it
        if (!await _roleManager.RoleExistsAsync("User"))
        {
            await _roleManager.CreateAsync(new ApplicationRole() { Name = "User", NormalizedName = "USER" });
        }


        IdentityResult roleAssignResult = await _userManager.AddToRoleAsync(user, "User");

        if (!roleAssignResult.Succeeded)
        {
            // TODO Check
            // TODO Make custom error that has to do with account management
            return CustomResult<IdentityResult>.Failure(CustomError.UnknownError("Something went wrong with user creation."));
        }

        return CustomResult<IdentityResult>.Success(result);
    }
}
