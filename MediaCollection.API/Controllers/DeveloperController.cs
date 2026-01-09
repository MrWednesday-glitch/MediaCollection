using MediaCollection.Domain.Models;
using System.Text;

namespace MediaCollection.API.Controllers;

// TODO Summaries
// TODO Unit tests
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
