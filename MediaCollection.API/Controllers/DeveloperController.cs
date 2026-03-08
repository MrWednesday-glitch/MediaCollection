using MediaCollection.Domain.Models;
using System.Text;

namespace MediaCollection.API.Controllers;

/// <summary>
/// The controller for dealing with <see cref="Developer"/> entities.
/// </summary>
[ApiController]
[Route("developers")]
public class DeveloperController : ControllerBase
{
    private readonly IDeveloperService _developerService;

    public DeveloperController(IDeveloperService developerService)
    {
        ArgumentNullException.ThrowIfNull(developerService);

        _developerService = developerService;
    }

    /// <summary>
    /// The controller endpoint to store developer information into the database.
    /// </summary>
    /// <param name="DeveloperToBe">The information needed to store developers into the database.</param>
    [HttpPost(Name = "PostDevelopers")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostDevelopers([FromBody] DeveloperToBe[] DeveloperToBe)
    {
        CustomResult<IEnumerable<Developer>> createdDevelopersResult = await _developerService.Add(DeveloperToBe);

        if (createdDevelopersResult.IsFailure)
        {
            return BadRequest(new ErrorDetails(
                string.Empty,
                createdDevelopersResult.Error.CustomErrorInformation.Message,
                createdDevelopersResult.Error.CustomErrorInformation.StatusCode,
                string.Empty,
                HttpContext.Request.Path));
        }

        IEnumerable<Developer> createdDevelopers = createdDevelopersResult.Value;
        StringBuilder stringBuilder = new();
        foreach (Developer createdDeveloper in createdDevelopers)
        {
            stringBuilder.Append($@"/developers/{createdDeveloper.Id},");
        }

        return Created(stringBuilder.ToString(), createdDevelopers);
    }
}
