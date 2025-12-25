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
                .AddJsonFile("local.settings.json", true, true)
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
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "HarperTorch"
        };
        var warnerBros = new Publisher
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "Warner Bros. Pictures",
            PictureUri = "https://www.fotolip.com/wp-content/uploads/2016/05/Warner-Bros-logo-23.jpg",
        };
        var supergiantGamesPub = new Publisher
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Name = "Supergiant Games"
        };
        var squarePub = new Publisher
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            Name = "Square",
            PictureUri = "https://www.square-enix-games.com/home/public/selogo_onwhite.jpg",
        };
        var yCGPub = new Publisher
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            Name = "Yacht Club Games",
            PictureUri = "https://images.nintendolife.com/9081f8a938747/yacht-club-games.original.jpg",
        };
        var zaumPub = new Publisher
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            Name = "ZA/UM",
            PictureUri = "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png",
        };

        var georgeMiller = new Director
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
            Name = "George Miller",
            PictureUri = "https://i1.wp.com/www.filminquiry.com/wp-content/uploads/2020/05/George-Miller.jpg?fit=1050%2C700&ssl=1",
        };
        var neilGaiman = new Author
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
            Name = "Neil Gaiman",
            PictureUri = "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1687,w_2999,x_0,y_0/dpr_1.5/c_limit,w_1600/fl_lossy,q_auto/v1610347631/210108-leon-neil-gaiman-hero_vhtgng",
        };
        var supergiantGamesDev = new Developer
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
            Name = "Supergiant Games"
        };
        var squareDev = new Developer
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
            Name = "Square Product Development Division 1"
        };
        var yCGDev = new Developer
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
            Name = "Yacht Club Games"
        };
        var zaumDev = new Developer
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
            Name = "ZA/UM",
            PictureUri = "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png",
        };

        var hades = new Game
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
            DeveloperId = supergiantGamesDev.Id,
            Finished = true,
            Owned = true,
            Name = "Hades",
            ReleaseDate = new DateTime(2020, 09, 17),
            OwnedOn = "Steam",
            PublisherId = supergiantGamesPub.Id,
            PictureUri = "https://image.api.playstation.com/vulcan/ap/rnd/202104/0517/9AcM3vy5t77zPiJyKHwRfnNT.png",
        };
        var americanGods = new Book
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
            ReleaseDate = new DateTime(2001, 01, 01),
            AuthorId = neilGaiman.Id,
            Name = "American Gods",
            Owned = true,
            PublisherId = harperTorch.Id,
            PictureUri = "https://1.bp.blogspot.com/-sIcmR6Ve9uk/UT4G1N7iAaI/AAAAAAAASJU/KEzdlynscVE/s1600/american-gods-ebook-9788499185415.jpg",
        };
        var furyRoad = new Film
        {
            DirectorId = georgeMiller.Id,
            ReleaseDate = new DateTime(2015, 05, 07),
            Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
            Name = "Mad Max: Fury Road",
            Owned = false,
            PublisherId = warnerBros.Id,
            PictureUri = "https://cdn.traileraddict.com/content/warner-bros-pictures/mad_max_fury_road-7.jpg",
        };
        var finalFantasyX = new Game
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
            Finished = true,
            Name = "Final Fantasy 10",
            Owned = true,
            ReleaseDate = new DateTime(2002, 05, 24),
            OwnedOn = "Playstation 2",
            DeveloperId = squareDev.Id,
            PublisherId = squarePub.Id,
            PictureUri = "https://m.media-amazon.com/images/I/91rQrZ+BRHL._AC_SL1500_.jpg",
        };
        var shovelKnight = new Game
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
            Finished = true,
            Name = "Shovel Knight",
            Owned = true,
            ReleaseDate = new DateTime(2014, 06, 26),
            OwnedOn = "Steam",
            DeveloperId = yCGDev.Id,
            PublisherId = yCGPub.Id,
            PictureUri = "https://www.gamespot.com/a/uploads/scale_medium/mig/0/0/6/2/2230062-box_sk.png"
        };
        var discoElysium = new Game
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
            Finished = false,
            Name = "Disco Elysium",
            Owned = true,
            ReleaseDate = new DateTime(2019, 10, 15),
            OwnedOn = "GOG",
            DeveloperId = zaumDev.Id,
            PublisherId = zaumPub.Id,
            PictureUri = "https://static0.gamerantimages.com/wordpress/wp-content/uploads/2022/10/disco-elysium-final-cut.jpg"
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
