using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data;

[ExcludeFromCodeCoverage]
public class MediaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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
        // Uncomment this and add the proper connString when I need to do a migration
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MediaCollection;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ApplicationUser ravenUser = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000100"),
            UserName = "raven",
            NormalizedUserName = "RAVEN",
            Email = "raven@email.me",
            NormalizedEmail = "RAVEN@EMAIL.ME",
            EmailConfirmed = true,
            FirstName = "Raven",
            LastName = "Admin",
            SecurityStamp = "00000000-0000-0000-0000-000000000101",
            ConcurrencyStamp = "00000000-0000-0000-0000-000000000102",
            CreatedOn = new DateTime(2026, 04, 07),
            PasswordHash = "AQAAAAIAAYagAAAAEONZCmRor5ViDWUuCcXlUXbbYiiYpJnAvxjQjA20nLqzX1Ons1dXsgtx60VCU/BXww==" // Password!234
        };

        Publisher harperTorch = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "HarperTorch"
        };
        Publisher warnerBros = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "Warner Bros. Pictures",
            PictureUri = "https://www.fotolip.com/wp-content/uploads/2016/05/Warner-Bros-logo-23.jpg",
        };
        Publisher supergiantGamesPub = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Name = "Supergiant Games"
        };
        Publisher squarePub = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            Name = "Square",
            PictureUri = "https://www.square-enix-games.com/home/public/selogo_onwhite.jpg",
        };
        Publisher yCGPub = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            Name = "Yacht Club Games",
            PictureUri = "https://images.nintendolife.com/9081f8a938747/yacht-club-games.original.jpg",
        };
        Publisher zaumPub = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            Name = "ZA/UM",
            PictureUri = "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png",
        };

        Director georgeMiller = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
            Name = "George Miller",
            PictureUri = "https://i1.wp.com/www.filminquiry.com/wp-content/uploads/2020/05/George-Miller.jpg?fit=1050%2C700&ssl=1",
        };
        Author neilGaiman = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
            Name = "Neil Gaiman",
            PictureUri = "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1687,w_2999,x_0,y_0/dpr_1.5/c_limit,w_1600/fl_lossy,q_auto/v1610347631/210108-leon-neil-gaiman-hero_vhtgng",
        };
        Developer supergiantGamesDev = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
            Name = "Supergiant Games"
        };
        Developer squareDev = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
            Name = "Square Product Development Division 1"
        };
        Developer yCGDev = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
            Name = "Yacht Club Games"
        };
        Developer zaumDev = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
            Name = "ZA/UM",
            PictureUri = "https://videogames.si.com/.image/t_share/MjA0MzY3MDI4MDcxNDQyMjA4/zaum-studio-logo-1.png",
        };

        Game hades = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
            DeveloperId = supergiantGamesDev.Id,
            //Finished = true,
            //Owned = true,
            Name = "Hades",
            ReleaseDate = new DateTime(2020, 09, 17),
            //OwnedOn = "Steam",
            PublisherId = supergiantGamesPub.Id,
            PictureUri = "https://image.api.playstation.com/vulcan/ap/rnd/202104/0517/9AcM3vy5t77zPiJyKHwRfnNT.png",
        };
        Book americanGods = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
            ReleaseDate = new DateTime(2001, 01, 01),
            AuthorId = neilGaiman.Id,
            Name = "American Gods",
            //Owned = true,
            PublisherId = harperTorch.Id,
            PictureUri = "https://1.bp.blogspot.com/-sIcmR6Ve9uk/UT4G1N7iAaI/AAAAAAAASJU/KEzdlynscVE/s1600/american-gods-ebook-9788499185415.jpg",
        };
        Film furyRoad = new()
        {
            DirectorId = georgeMiller.Id,
            ReleaseDate = new DateTime(2015, 05, 07),
            Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
            Name = "Mad Max: Fury Road",
            //Owned = false,
            PublisherId = warnerBros.Id,
            PictureUri = "https://cdn.traileraddict.com/content/warner-bros-pictures/mad_max_fury_road-7.jpg",
        };
        Game finalFantasyX = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
            //Finished = true,
            Name = "Final Fantasy 10",
            //Owned = true,
            ReleaseDate = new DateTime(2002, 05, 24),
            //OwnedOn = "Playstation 2",
            DeveloperId = squareDev.Id,
            PublisherId = squarePub.Id,
            PictureUri = "https://m.media-amazon.com/images/I/91rQrZ+BRHL._AC_SL1500_.jpg",
        };
        Game shovelKnight = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
            //Finished = true,
            Name = "Shovel Knight",
            //Owned = true,
            ReleaseDate = new DateTime(2014, 06, 26),
            //OwnedOn = "Steam",
            DeveloperId = yCGDev.Id,
            PublisherId = yCGPub.Id,
            PictureUri = "https://www.gamespot.com/a/uploads/scale_medium/mig/0/0/6/2/2230062-box_sk.png"
        };
        Game discoElysium = new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
            //Finished = false,
            Name = "Disco Elysium",
            //Owned = true,
            ReleaseDate = new DateTime(2019, 10, 15),
            //OwnedOn = "GOG",
            DeveloperId = zaumDev.Id,
            PublisherId = zaumPub.Id,
            PictureUri = "https://static0.gamerantimages.com/wordpress/wp-content/uploads/2022/10/disco-elysium-final-cut.jpg"
        };

        UserBook ravenAmericanGods = new()
        {
            UserId = ravenUser.Id,
            BookId = americanGods.Id,
            Owned = true,
        };
        UserFilm ravenFuryRoad = new()
        {
            UserId = ravenUser.Id,
            FilmId = furyRoad.Id,
            Owned = false,
        };
        UserGame ravenFinalFantasyX = new()
        {
            UserId = ravenUser.Id,
            GameId = finalFantasyX.Id,
            Owned = true,
            Finished = true,
            OwnedOn = "Playstation 2"
        };
        UserGame ravenShovelKnight = new()
        {
            UserId = ravenUser.Id,
            GameId = shovelKnight.Id,
            Owned = true,
            Finished = true,
            OwnedOn = "Steam"
        };
        UserGame ravenDiscoElysium = new()
        {
            UserId = ravenUser.Id,
            GameId = discoElysium.Id,
            Owned = true,
            Finished = true,
            OwnedOn = "GOG"
        };
        UserGame ravenHades = new()
        {
            UserId = ravenUser.Id,
            GameId = hades.Id,
            Owned = true,
            Finished = true,
            OwnedOn = "Steam"
        };

        modelBuilder.Entity<ApplicationUser>().HasData(ravenUser);

        modelBuilder.Entity<Publisher>().HasData([harperTorch, warnerBros, supergiantGamesPub, squarePub, zaumPub, yCGPub]);
        modelBuilder.Entity<Director>().HasData(georgeMiller);
        modelBuilder.Entity<Author>().HasData(neilGaiman);
        modelBuilder.Entity<Developer>().HasData([supergiantGamesDev, zaumDev, squareDev, yCGDev]);
        modelBuilder.Entity<Film>().HasData(furyRoad);
        modelBuilder.Entity<Game>().HasData([hades, discoElysium, shovelKnight, finalFantasyX]);
        modelBuilder.Entity<Book>().HasData(americanGods);

        modelBuilder.Entity<UserGame>().HasData([ravenHades, ravenDiscoElysium, ravenShovelKnight, ravenFinalFantasyX]);
        modelBuilder.Entity<UserBook>().HasData(ravenAmericanGods);
        modelBuilder.Entity<UserFilm>().HasData(ravenFuryRoad);

        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

        modelBuilder.Entity<UserGame>()
            .HasKey(ug => new { ug.UserId, ug.GameId });
        modelBuilder.Entity<UserGame>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.UserGames)
            .HasForeignKey(ug => ug.UserId);
        modelBuilder.Entity<UserGame>()
            .HasOne(ug => ug.Game)
            .WithMany(g => g.UserGames)
            .HasForeignKey(ug => ug.GameId);

        modelBuilder.Entity<UserFilm>()
            .HasKey(uF => new { uF.UserId, uF.FilmId });
        modelBuilder.Entity<UserFilm>()
            .HasOne(uF => uF.User)
            .WithMany(u => u.UserFilms)
            .HasForeignKey(uF => uF.UserId);
        modelBuilder.Entity<UserFilm>()
            .HasOne(uF => uF.Film)
            .WithMany(f => f.UserFilms)
            .HasForeignKey(uF => uF.FilmId);

        modelBuilder.Entity<UserBook>()
            .HasKey(uB => new { uB.UserId, uB.BookId });
        modelBuilder.Entity<UserBook>()
            .HasOne(uB => uB.User)
            .WithMany(u => u.UserBooks)
            .HasForeignKey(uB => uB.UserId);
        modelBuilder.Entity<UserBook>()
            .HasOne(uB => uB.Book)
            .WithMany(b => b.UserBooks)
            .HasForeignKey(uB => uB.BookId);

        base.OnModelCreating(modelBuilder);
    }
}
