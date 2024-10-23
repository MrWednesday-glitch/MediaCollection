using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace MediaCollection.Data;

[ExcludeFromCodeCoverage]
public class MediaDbContext : DbContext
{
    public MediaDbContext()
    {
    }

    public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Film> Films { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Developer> Developers { get; set; }

    public DbSet<Director> Directors { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", false, true)
                .Build();
            string connectionString = configBuilder.GetConnectionString("LocalDb")
                ?? throw new ArgumentNullException("No Connectionstring found.");

            optionsBuilder.UseSqlServer(connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var harperTorch = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "HarperTorch"
        };
        var warnerBros = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "Warner Bros. Pictures"
        };
        var supergiantGamesPub = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "Supergiant Games"
        };
        var squarePub = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "Square"
        };
        var yCGPub = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "Yacht Club Games"
        };
        var zaumPub = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "ZA/UM"
        };

        var georgeMiller = new Director
        {
            Id = Guid.NewGuid(),
            Name = "George Miller"
        };
        var neilGaiman = new Author
        {
            Id = Guid.NewGuid(),
            Name = "Neil Gaiman"
        };
        var supergiantGamesDev = new Developer
        {
            Id = Guid.NewGuid(),
            Name = "Supergiant Games"
        };
        var squareDev = new Developer
        {
            Id = Guid.NewGuid(),
            Name = "Square Product Development Division 1"
        };
        var yCGDev = new Developer
        {
            Id = Guid.NewGuid(),
            Name = "Yacht Club Games"
        };
        var zaumDev = new Developer
        {
            Id = Guid.NewGuid(),
            Name = "ZA/UM"
        };

        var hades = new Game
        {
            Id = Guid.NewGuid(),
            DeveloperId = supergiantGamesDev.Id,
            Finished = true,
            Owned = true,
            Name = "Hades",
            ReleaseDate = new DateTime(2020, 09, 17),
            OwnedOn = "Steam",
            PublisherId = supergiantGamesPub.Id,
        };
        var americanGods = new Book
        {
            Id = Guid.NewGuid(),
            ReleaseDate = new DateTime(2001, 01, 01),
            AuthorId = neilGaiman.Id,
            Name = "American Gods",
            Owned = true,
            PublisherId = harperTorch.Id,
        };
        var furyRoad = new Film
        {
            DirectorId = georgeMiller.Id,
            ReleaseDate = new DateTime(2015, 05, 07),
            Id = Guid.NewGuid(),
            Name = "Mad Max: Fury Road",
            Owned = false,
            PublisherId = warnerBros.Id,
        };
        var finalFantasyX = new Game
        {
            Id = Guid.NewGuid(),
            Finished = true,
            Name = "Final Fantasy 10",
            Owned = true,
            ReleaseDate = new DateTime(2002, 05, 24),
            OwnedOn = "Playstation 2",
            DeveloperId = squareDev.Id,
            PublisherId = squarePub.Id,
        };
        var shovelKnight = new Game
        {
            Id = Guid.NewGuid(),
            Finished = true,
            Name = "Shovel Knight",
            Owned = true,
            ReleaseDate = new DateTime(2014, 06, 26),
            OwnedOn = "Steam",
            DeveloperId = yCGDev.Id,
            PublisherId = yCGPub.Id,
        };
        var discoElysium = new Game
        {
            Id = Guid.NewGuid(),
            Finished = false,
            Name = "Disco Elysium",
            Owned = true,
            ReleaseDate = new DateTime(2019, 10, 15),
            OwnedOn = "GOG",
            DeveloperId = zaumDev.Id,
            PublisherId = zaumPub.Id,
        };


        modelBuilder.Entity<Publisher>().HasData([harperTorch, warnerBros, supergiantGamesPub, squarePub, zaumPub, yCGPub]);
        modelBuilder.Entity<Director>().HasData(georgeMiller);
        modelBuilder.Entity<Author>().HasData(neilGaiman);
        modelBuilder.Entity<Developer>().HasData([supergiantGamesDev, zaumDev, squareDev, yCGDev]);
        modelBuilder.Entity<Film>().HasData(furyRoad);
        modelBuilder.Entity<Game>().HasData([hades, discoElysium, shovelKnight, finalFantasyX]);
        modelBuilder.Entity<Book>().HasData(americanGods);

        base.OnModelCreating(modelBuilder);
    }
}
