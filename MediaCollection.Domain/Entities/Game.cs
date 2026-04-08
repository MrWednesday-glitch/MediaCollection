namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Game : Media
{
    public Guid DeveloperId { get; set; }

    public virtual Developer Developer { get; set; } = null!;

    public virtual ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
}
