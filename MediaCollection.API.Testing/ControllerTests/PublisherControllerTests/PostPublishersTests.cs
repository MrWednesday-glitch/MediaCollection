namespace MediaCollection.API.Testing.ControllerTests.PublisherControllerTests;

[ExcludeFromCodeCoverage]
public class PostPublishersTests
{
    [Fact]
    public async Task Should_ReturnASuccesfulCreated_When_AllGoesWell()
    {
        // -- Arrange
        Mock<IPublisherService> mockedService = new();
        List<Publisher> createdPublishers = new()
        {
            new Publisher()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Electronic Arts",
                PictureUri = null
            },
            new Publisher()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Ubisoft",
                PictureUri = null
            },
        };
        mockedService
            .Setup(s => s.Add(It.IsAny<IEnumerable<PublisherToBe>>()))
            .Returns(Task.FromResult(createdPublishers.AsEnumerable()))
            .Verifiable(Times.Once);
        PublisherController controller = new(mockedService.Object);
        PublisherToBe[] toBeCreatedPublishers =
            [
            new()
            {
                Name = "Electronic Arts",
                PictureUri = null
            },
            new()
            {
                Name = "Unisoft",
                PictureUri = null
            }
            ];

        // -- Act
        IActionResult result = await controller.PostPublishers(toBeCreatedPublishers);

        // -- Assert
        mockedService.Verify();

        CreatedResult createdResult = result.Should().BeAssignableTo<CreatedResult>().Subject;
        createdResult.StatusCode.Should().Be(StatusCodes.Status201Created);

        IEnumerable<Publisher> returnedPublishers = createdResult.Value
            .Should().BeAssignableTo<IEnumerable<Publisher>>().Subject;
        returnedPublishers.Should().HaveCount(2);
        returnedPublishers.Should().BeEquivalentTo(createdPublishers);
    }

    [Fact]
    public async Task Should_ReturnABadRequest_When_ThingsGoWrong()
    {
        // -- Arrange
        Mock<IPublisherService> mockedService = new();
        mockedService
            .Setup(s => s.Add(It.IsAny<IEnumerable<PublisherToBe>>()))
            .ThrowsAsync(new Exception("Something went wrong!"));
        PublisherController controller = new(mockedService.Object);
        PublisherToBe[] toBeCreatedPublishers =
            [
            new()
            {
                Name = "Electronic Arts",
                PictureUri = null
            },
            new()
            {
                Name = "Unisoft",
                PictureUri = null
            }
            ];

        // -- Act
        IActionResult result = await controller.PostPublishers(toBeCreatedPublishers);

        // -- Assert
        result
            .Should().BeOfType<BadRequestObjectResult>()
            .Which.Value
            .Should().Be("Something went wrong!");
    }
}
