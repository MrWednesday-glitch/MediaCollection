using MediaCollection.Domain.Enums;
using MediaCollection.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MediaCollection.API.Controllers;

// TODO Unit test
// TODO Write summaries
[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        CustomResult<IdentityResult> customResult = await _accountService.RegisterUserAsync(model);

        if (customResult.IsSuccess)
        {
            return StatusCode(201, customResult.Value);
        }

        return customResult.Error.Code switch
        {
            ErrorCodes.UnknownError => BadRequest(new ErrorDetails(
                string.Empty,
                customResult.Error.CustomErrorInformation.Message,
                400,
                string.Empty,
                HttpContext.Request.Path)),
            _ => StatusCode(500, new ErrorDetails(
                string.Empty,
                customResult.Error.CustomErrorInformation.Message,
                 500,
                string.Empty,
                HttpContext.Request.Path))
        };
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        CustomResult<LogInResult> result = await _accountService.LoginUserAsync(model);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return result.Error.Code switch
        {
            ErrorCodes.RecordNotFound => NotFound(new ErrorDetails(
                string.Empty,
                result.Error.CustomErrorInformation.Message,
                404,
                string.Empty,
                HttpContext.Request.Path)),
            ErrorCodes.UserNotConfirmed => BadRequest(new ErrorDetails(
                string.Empty,
                result.Error.CustomErrorInformation.Message,
                400,
                string.Empty,
                HttpContext.Request.Path)),
            ErrorCodes.Unauthorized => Unauthorized(new ErrorDetails(
                string.Empty,
                result.Error.CustomErrorInformation.Message,
                401,
                string.Empty,
                HttpContext.Request.Path)),
            _ => StatusCode(500, new ErrorDetails(
                string.Empty,
                result.Error.CustomErrorInformation.Message,
                 500,
                string.Empty,
                HttpContext.Request.Path))
        };
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

        CustomResult<ProfileViewModel> userResult = await _accountService.GetUserProfileByEmailAsync(email);

        if (userResult.IsSuccess)
        {
            return Ok(userResult.Value);
        }

        return userResult.Error.Code switch
        {
            ErrorCodes.UnknownError => BadRequest(new ErrorDetails(
                string.Empty,
                userResult.Error.CustomErrorInformation.Message,
                400,
                string.Empty,
                HttpContext.Request.Path)),
            ErrorCodes.RecordNotFound => NotFound(new ErrorDetails(
                string.Empty,
                userResult.Error.CustomErrorInformation.Message,
                404,
                string.Empty,
                HttpContext.Request.Path)),
            _ => StatusCode(500, new ErrorDetails(
                string.Empty,
                userResult.Error.CustomErrorInformation.Message,
                 500,
                string.Empty,
                HttpContext.Request.Path))
        };
    }
}
