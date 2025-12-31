using MediaCollection.Domain.Models;
using System.Text;

namespace MediaCollection.API.Controllers;

// TODO Summaries
//TODO Unit tests
[ApiController]
[Route("publishers")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        ArgumentNullException.ThrowIfNull(publisherService);

        _publisherService = publisherService;
    }

    [HttpPost(Name = "PostPublishers")]
    public async Task<IActionResult> PostPublishers([FromBody]PublisherToBe[] publishersToBe)
    {
        try
        {
            Publisher[] createdPublishers = await _publisherService.Add(publishersToBe);

            StringBuilder stringBuilder = new();
            foreach (var createdPublisher in createdPublishers)
            {
                stringBuilder.Append($@"/publishers/{createdPublisher.Id},");
            }

            return Created(stringBuilder.ToString(), createdPublishers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
