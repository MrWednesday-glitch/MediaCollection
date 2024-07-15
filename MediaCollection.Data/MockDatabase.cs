using MediaCollection.Domain.Entities;

namespace MediaCollection.Data;

public class MockDatabase
{
    private readonly List<Game> _games = new()
    {
        new()
        {
            Id = 1,
            Finished = true,
            Name = "Shovel Knight",
            Owned = true,
            ReleaseDate = new DateTime(2014, 06, 26),
            OwnedOn = "Steam",
            DeveloperId = 1,
            PublisherId = 1,
            Developer = new Developer()
            {
                Id = 1,
                Name = "Yacht Club Games"
            },
            Publisher = new Publisher()
            {
                Id = 1,
                Name = "Yacht Club Games"
            }
        },
        new()
        {
            Id = 2,
            Finished = false,
            Name = "Disco Elysium",
            Owned = true,
            ReleaseDate = new DateTime(2019, 10, 15),
            OwnedOn = "GOG",
            DeveloperId = 2,
            PublisherId = 2,
            Developer = new Developer()
            {
                Id = 2,
                Name = "ZA/UM"
            },
            Publisher = new Publisher()
            {
                Id = 2,
                Name = "ZA/UM"
            }
        },
        new()
        {
            Id = 3,
            Finished = true,
            Name = "Final Fantasy 10",
            Owned = true,
            ReleaseDate = new DateTime(2002, 05, 24),
            OwnedOn = "Playstation 2",
            DeveloperId = 3,
            PublisherId = 3,
            Developer = new Developer()
            {
                Id = 3,
                Name = "Square Product Development Division 1"
            },
            Publisher = new Publisher()
            {
                Id = 3,
                Name = "Square"
            }
        },
    };

    public List<Game> Get() => _games;
}
