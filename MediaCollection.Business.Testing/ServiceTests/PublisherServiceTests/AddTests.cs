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
        List<Publisher> publishers = (await publisherService.AddAsync(publishersToBe)).Value.ToList();

        // -- Assert
        publishers.Should().HaveCount(0);
    }

    [Fact]
    public async Task Should_FollowTheHappyPath()
    {
        IEnumerable<PublisherToBe> publishersToBe = new List<PublisherToBe>()
        {
            new PublisherToBe()
            {
                Name = "2K",
                PictureUri = "www.dinotopia.com"
            }
        };
        Mock<IPublisherRepository> mockedRepo = new();
        mockedRepo
            .Setup(x => x.GetAsync())
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(x => x.CreateRecordsAsync(It.IsAny<IEnumerable<Publisher>>()))
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(x => x.SaveChangesAsync())
            .Verifiable(Times.Once);
        IPublisherService publisherService = new PublisherService(mockedRepo.Object);

        List<Publisher> publishers = (await publisherService.AddAsync(publishersToBe)).Value.ToList();

        publishers.Should().HaveCount(1);
        mockedRepo.Verify();
    }

    [Fact]
    public async Task Should_FollowTheHappyPath_And_RemoveDuplicates()
    {
        IEnumerable<PublisherToBe> publishersToBe = new List<PublisherToBe>()
        {
            new PublisherToBe()
            {
                Name = "2K",
                PictureUri = "www.dinotopia.com"
            },
            new PublisherToBe()
            {
                Name = "2K",
                PictureUri = "www.dinotopia.com"
            }
        };
        Mock<IPublisherRepository> mockedRepo = new();
        mockedRepo
            .Setup(x => x.GetAsync())
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(x => x.CreateRecordsAsync(It.IsAny<IEnumerable<Publisher>>()))
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(x => x.SaveChangesAsync())
            .Verifiable(Times.Once);
        IPublisherService publisherService = new PublisherService(mockedRepo.Object);

        List<Publisher> publishers = (await publisherService.AddAsync(publishersToBe)).Value.ToList();

        publishers.Should().HaveCount(1);
        mockedRepo.Verify();
    }

    [Fact]
    public async Task Should_ProperlyDealWithEntitiesThatAlreadyExist()
    {
        IEnumerable<PublisherToBe> publishersToBe = new List<PublisherToBe>()
        {
            new()
            {
                Name = "2K",
                PictureUri = "www.dinotopia.com"
            },
            new()
            {
                Name = "EA",
                PictureUri = "www.flaaafffyyyy.com"
            }
        };
        Mock<IPublisherRepository> mockedRepo = new();
        IEnumerable<Publisher> existingPublishers = new List<Publisher>()
        {
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                Name = "EA",
                PictureUri = "www.flaaafffyyyy.com"
            }
        };
        mockedRepo
            .Setup(x => x.GetAsync())
            .ReturnsAsync(existingPublishers.AsQueryable)
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(x => x.CreateRecordsAsync(It.IsAny<IEnumerable<Publisher>>()))
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(x => x.SaveChangesAsync())
            .Verifiable(Times.Once);
        IPublisherService publisherService = new PublisherService(mockedRepo.Object);

        List<Publisher> publishers = (await publisherService.AddAsync(publishersToBe)).Value.ToList();

        publishers.Should().HaveCount(2);
        mockedRepo.Verify();

        Publisher publisher2K = publishers.First(x => x.Name.Equals("2K"));
        Publisher publisherEA = publishers.First(x => x.Name.Equals("EA"));

        publisher2K.Id.Should().Be(Guid.Parse("00000000-0000-0000-0000-000000000000"));
        publisherEA.Id.Should().Be(Guid.Parse("10000000-0000-0000-0000-000000000001"));
    }
}
