using MediaCollection.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MediaCollection.API.Controllers;

// TODO Unit test
// TODO Write summaries
// TODO Rewrite this to the result pattern
[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    // TODO Ensure that IAccountService and AccountService are in the DI container
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _accountService.RegisterUserAsync(model);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    Message = "Registration successful."
                });
            }

            return BadRequest(new
            {
                Errors = result.Errors.Select(e => e.Description)
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new
            {
                Message = "An unexpected error occurred."
            });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomResult<LogInResult> result = await _accountService.LoginUserAsync(model);

            return Ok(result.Value);

            // Move this to the service

            //if (result.IsNotAllowed)
            //{
            //    return Unauthorized(new
            //    {
            //        Message = "Email is not confirmed."
            //    });
            //}

            //return Unauthorized(new
            //{
            //    Message = "Invalid login attempt."
            //});
        }
        catch (Exception)
        {
            return StatusCode(500, new
            {
                Message = "An unexpected error occurred."
            });
        }
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> ShowProfileAsync()
    {
        string? email = User.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrEmpty(email))
        {
            return Unauthorized(new
            {
                Message = "User not authenticated."
            });
        }

        try
        {
            ProfileViewModel model = await _accountService.GetUserProfileByEmailAsync(email);

            return Ok(model);
        }
        catch (ArgumentException)
        {
            return NotFound(new
            {
                Message = "User not found."
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new
            {
                Message = "An unexpected error occurred."
            });
        }
    }
}
