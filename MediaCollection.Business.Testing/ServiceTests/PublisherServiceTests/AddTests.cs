namespace MediaCollection.Business.Testing.ServiceTests.PublisherServiceTests;

[ExcludeFromCodeCoverage]
public class AddTests
{
    [Fact]
    public async Task Should_ReturnAnEmptyCollection_When_AnEmptyCollectionGoesIn()
    {
        // -- Arrange
        List<PublisherToBe> publishersToBe = new();
        IPublisherService publisherService = new PublisherService(Mock.Of<IPublisherRepository>());

        // -- Act
        List<Publisher> publishers = (await publisherService.Add(publishersToBe)).ToList();

        // -- Assert
        publishers.Should().HaveCount(0);
    }
}
