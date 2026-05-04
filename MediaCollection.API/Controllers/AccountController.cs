using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MediaCollection.API.Controllers;

[ApiController]
[Route("api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        ArgumentNullException.ThrowIfNull(accountService);

        _accountService = accountService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
