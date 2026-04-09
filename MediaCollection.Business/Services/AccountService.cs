using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Business.Services;

// TODO Write summaries
// TODO Write unit tests
public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly DateTimeWrapper _dateTimeWrapper;

    public AccountService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        DateTimeWrapper dateTimeWrapper)
    {
        ArgumentNullException.ThrowIfNull(userManager);
        ArgumentNullException.ThrowIfNull(signInManager);
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(dateTimeWrapper);

        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _dateTimeWrapper = dateTimeWrapper;
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

    public async Task<SignInResult> LoginUserAsync(LoginViewModel model)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            return SignInResult.Failed;
        }

        if (!await _userManager.IsEmailConfirmedAsync(user))
        {
            return SignInResult.NotAllowed;
        }

        SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName!, model.Password, model.RememberMe, lockoutOnFailure: false);

        return result;
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
    private DateTime? _dateTime;

    public DateTimeWrapper()
    {
        _dateTime = null;
    }

    public DateTimeWrapper(DateTime fixedDateTime)
    {
        _dateTime = fixedDateTime;
    }

    public DateTime Now
    { get
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
