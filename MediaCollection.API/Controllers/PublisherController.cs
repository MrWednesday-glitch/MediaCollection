using MediaCollection.Domain.Models;
using System.Text;

namespace MediaCollection.API.Controllers;

/// <summary>
/// The controller for dealing with <see cref="Publisher"/> entities.
/// </summary>
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

    /// <summary>
    /// The controller endpoint to store publisher information into the database.
    /// </summary>
    /// <param name="publishersToBe">The required information that needs to be send to the database.</param>
    [HttpPost(Name = "PostPublishers")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostPublishers([FromBody] PublisherToBe[] publishersToBe)
    {
        CustomResult<IEnumerable<Publisher>> createdPublishersResult = await _publisherService.Add(publishersToBe);

        if (createdPublishersResult.IsFailure)
        {
            return BadRequest(new ErrorDetails(
                string.Empty,
                createdPublishersResult.Error.CustomErrorInformation.Message,
                createdPublishersResult.Error.CustomErrorInformation.StatusCode,
                string.Empty,
                HttpContext.Request.Path));
        }

        IEnumerable<Publisher> createdPublishers = createdPublishersResult.Value;
        StringBuilder stringBuilder = new();
        foreach (Publisher createdPublisher in createdPublishers)
        {
            stringBuilder.Append($@"/publishers/{createdPublisher.Id},");
        }

        return Created(stringBuilder.ToString(), createdPublishers);
    }
}
