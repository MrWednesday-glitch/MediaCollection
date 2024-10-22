namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Game : Media
{
    public int DeveloperId { get; set; }

    public virtual Developer Developer { get; set; } = null!;

    public string? OwnedOn { get; set; }

    public bool Finished { get; set; }
}
