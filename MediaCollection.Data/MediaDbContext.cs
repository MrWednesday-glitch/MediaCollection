using MediaCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO Write Repositories
// TODO DI
// TODO Set up database
// TODO Set up automatic migration
namespace MediaCollection.Data;

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
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediaCollection;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var harperTorch = new Publisher
        {
            Id = 1,
            Name = "HarperTorch"
        };
        var warnerBros = new Publisher
        {
            Id = 2,
            Name = "Warner Bros. Pictures"
        };
        var supergiantGamesPub = new Publisher
        {
            Id = 3,
            Name = "Supergiant Games"
        };

        var georgeMiller = new Director
        {
            Id = 1,
            Name = "George Miller"
        };
        var neilGaiman = new Author
        {
            Id = 1,
            Name = "NeilGaiman"
        };
        var supergiantGamesDev = new Developer
        {
            Id = 1,
            Name = "Supergiant Games"
        };

        var hades = new Game
        {
            Id = 6,
            //Developer = supergiantGamesDev,
            DeveloperId = supergiantGamesDev.Id,
            Finished = true,
            Owned = true,
            Name = "Hades",
            ReleaseDate = new DateTime(2020, 09, 17),
            OwnedOn = "Steam",
            //Publisher = supergiantGamesPub,
            PublisherId = supergiantGamesPub.Id,
        };
        var americanGods = new Book
        {
            Id = 1,
            ReleaseDate = new DateTime(2001, 01, 01),
            //Author = neilGaiman,
            AuthorId = neilGaiman.Id,
            Name = "American Gods",
            Owned = true,
            //Publisher = harperTorch,
            PublisherId = harperTorch.Id,
        };
        var furyRoad = new Film
        {
            //Director = georgeMiller,
            DirectorId = georgeMiller.Id,
            ReleaseDate = new DateTime(2015, 05, 07),
            Id = 5,
            Name = "Mad Max: Fury Road",
            Owned = false,
            //Publisher = warnerBros,
            PublisherId = warnerBros.Id,
        };

        modelBuilder.Entity<Publisher>().HasData([harperTorch, warnerBros, supergiantGamesPub]);
        modelBuilder.Entity<Director>().HasData(georgeMiller);
        modelBuilder.Entity<Author>().HasData(neilGaiman);
        modelBuilder.Entity<Developer>().HasData(supergiantGamesDev);
        modelBuilder.Entity<Film>().HasData(furyRoad);
        modelBuilder.Entity<Game>().HasData(hades);
        modelBuilder.Entity<Book>().HasData(americanGods);

        base.OnModelCreating(modelBuilder);
    }
}
