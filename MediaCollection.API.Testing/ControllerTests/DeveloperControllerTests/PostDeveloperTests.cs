using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.API.Testing.ControllerTests.DeveloperControllerTests;

[ExcludeFromCodeCoverage]
public class PostDeveloperTests
{
    [Fact]
    public async Task Should_ReturnASuccesfulCreated_When_AllGoesWell()
    {
        // -- Arrange
        Mock<IDeveloperService> mockedService = new();
        List<Developer> createdDevelopers = new()
        {
            new Developer()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Gamefreak",
                PictureUri = null
            },
            new Developer()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "CD Projekt Red",
                PictureUri = null
            },
        };
        mockedService
            .Setup(s => s.Add(It.IsAny<IEnumerable<DeveloperToBe>>()))
            .Returns(Task.FromResult(createdDevelopers.AsEnumerable()))
            .Verifiable(Times.Once);
        DeveloperController controller = new(mockedService.Object);
        DeveloperToBe[] toBeCreatedDevelopers =
            [
            new()
            {
                Name = "Gamefreak",
                PictureUri = null
            },
            new()
            {
                Name = "CD Projekt Red",
                PictureUri = null
            }
            ];

        // -- Act
        IActionResult result = await controller.PostDevelopers(toBeCreatedDevelopers);

        // -- Assert
        mockedService.Verify();

        CreatedResult createdResult = result.Should().BeAssignableTo<CreatedResult>().Subject;
        createdResult.StatusCode.Should().Be(StatusCodes.Status201Created);

        IEnumerable<Developer> returnedDevelopers = createdResult.Value
            .Should().BeAssignableTo<IEnumerable<Developer>>().Subject;
        returnedDevelopers.Should().HaveCount(2);
        returnedDevelopers.Should().BeEquivalentTo(createdDevelopers);
    }

    [Fact]
    public async Task Should_ReturnABadRequest_When_ThingsGoWrong()
    {
        // -- Arrange
        Mock<IDeveloperService> mockedService = new();
        mockedService
            .Setup(s => s.Add(It.IsAny<IEnumerable<DeveloperToBe>>()))
            .ThrowsAsync(new Exception("Something went wrong!"));
        DeveloperController controller = new(mockedService.Object);
        DeveloperToBe[] toBeCreatedDevelopers =
            [
            new()
            {
                Name = "Gamefreak",
                PictureUri = null
            },
            new()
            {
                Name = "CD Projekt Red",
                PictureUri = null
            }
            ];

        // -- Act
        IActionResult result = await controller.PostDevelopers(toBeCreatedDevelopers);

        // -- Assert
        result
            .Should().BeOfType<BadRequestObjectResult>()
            .Which.Value
            .Should().Be("Something went wrong!");
    }
}
