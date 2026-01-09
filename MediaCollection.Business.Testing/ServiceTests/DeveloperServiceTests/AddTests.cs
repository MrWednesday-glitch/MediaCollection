namespace MediaCollection.Business.Testing.ServiceTests.DeveloperServiceTests;

[ExcludeFromCodeCoverage]
public class AddTests
{
    [Fact]
    public async Task Should_ReturnAnEmptyCollection_When_AnEmptyCollectionGoesIn()
    {
        // -- Arrange
        List<DeveloperToBe> developersToBe = new();
        IDeveloperService developerService = new DeveloperService(Mock.Of<IDeveloperRepository>());

        // -- Act
        List<Developer> developers = (await developerService.Add(developersToBe)).ToList();

        // -- Assert
        developers.Should().HaveCount(0);
    }

    [Fact]
    public async Task Should_FollowTheHappyPath()
    {
        IEnumerable<DeveloperToBe> developersToBe = new List<DeveloperToBe>()
        {
            new DeveloperToBe()
            {
                Name = "Gamefreak",
                PictureUri = "www.dinotopia.com"
            }
        };
        Mock<IDeveloperRepository> mockedRepo = new();
        mockedRepo
            .Setup(dR => dR.Get())
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(dR => dR.CreateRecords(It.IsAny<IEnumerable<Developer>>()))
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(dR => dR.SaveChanges())
            .Verifiable(Times.Once);
        IDeveloperService developerService = new DeveloperService(mockedRepo.Object);

        List<Developer> developers = (await developerService.Add(developersToBe)).ToList();

        developers.Should().HaveCount(1);
        mockedRepo.Verify();
    }

    [Fact]
    public async Task Should_FollowTheHappyPath_And_RemoveDuplicates()
    {
        IEnumerable<DeveloperToBe> developersToBe = new List<DeveloperToBe>()
        {
            new ()
            {
                Name = "Gamefreak",
                PictureUri = "www.dinotopia.com"
            },
            new ()
            {
                Name = "Gamefreak",
                PictureUri = "www.dinotopia.com"
            }
        };
        Mock<IDeveloperRepository> mockedRepo = new();
        mockedRepo
            .Setup(dR => dR.Get())
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(dR => dR.CreateRecords(It.IsAny<IEnumerable<Developer>>()))
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(dR => dR.SaveChanges())
            .Verifiable(Times.Once);
        IDeveloperService developerService = new DeveloperService(mockedRepo.Object);

        List<Developer> developers = (await developerService.Add(developersToBe)).ToList();

        developers.Should().HaveCount(1);
        mockedRepo.Verify();
    }

    [Fact]
    public async Task Should_ProperlyDealWithEntitiesThatAlreadyExist()
    {
        IEnumerable<DeveloperToBe> developersToBe = new List<DeveloperToBe>()
        {
            new()
            {
                Name = "Gamefreak",
                PictureUri = "www.dinotopia.com"
            },
            new()
            {
                Name = "Lolz",
                PictureUri = "www.flaaafffyyyy.com"
            }
        };
        Mock<IDeveloperRepository> mockedRepo = new();
        IEnumerable<Developer> existingDevelopers = new List<Developer>()
        {
            new()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                Name = "Lolz",
                PictureUri = "www.flaaafffyyyy.com"
            }
        };
        mockedRepo
            .Setup(dR => dR.Get())
            .ReturnsAsync(existingDevelopers.AsQueryable)
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(dR => dR.CreateRecords(It.IsAny<IEnumerable<Developer>>()))
            .Verifiable(Times.Once);
        mockedRepo
            .Setup(dR => dR.SaveChanges())
            .Verifiable(Times.Once);
        IDeveloperService developerService = new DeveloperService(mockedRepo.Object);

        List<Developer> developers = (await developerService.Add(developersToBe)).ToList();

        developers.Should().HaveCount(2);
        mockedRepo.Verify();

        Developer developerGamefreak = developers.First(d => d.Name.Equals("Gamefreak"));
        Developer developerLolz = developers.First(d => d.Name.Equals("Lolz"));

        developerGamefreak.Id.Should().Be(Guid.Parse("00000000-0000-0000-0000-000000000000"));
        developerLolz.Id.Should().Be(Guid.Parse("10000000-0000-0000-0000-000000000001"));
    }
}
