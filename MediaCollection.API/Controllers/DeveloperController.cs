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
    public async Task<IActionResult> PostDevelopers([FromBody] DeveloperToBe[] DeveloperToBe)
    {
        try
        {
            IEnumerable<Developer> createdDevelopers = await _developerService.Add(DeveloperToBe);

            StringBuilder stringBuilder = new();
            foreach (Developer createdDeveloper in createdDevelopers)
            {
                stringBuilder.Append($@"/developers/{createdDeveloper.Id},");
            }

            return Created(stringBuilder.ToString(), createdDevelopers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
