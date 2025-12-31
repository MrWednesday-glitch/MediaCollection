using MediaCollection.Domain.Models;

namespace MediaCollection.API.Controllers;

// TODO Summaries
//TODO Unit tests
[ApiController]
[Route("publishers")]
public class PublisherController : ControllerBase
{
    // TODO Make service, interface, and add to DI container
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        ArgumentNullException.ThrowIfNull(publisherService);

        _publisherService = publisherService;
    }

    [HttpPost(Name = "PostPublishers")]
    public async Task<IActionResult> PostPublishers([FromBody]PublisherToBe[] publisherToBe)
    {
        try
        {
            Publisher[] createdPublishers = ...;

            return Created("", createdPublishers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
