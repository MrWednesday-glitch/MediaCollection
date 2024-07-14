namespace MediaCollection.Domain.Entities;

public class Game : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public int DeveloperId { get; set; }

    public virtual Developer Developer { get; set; } = null!;

    public int PublisherId { get; set; }

    public virtual Publisher Publisher { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public bool Owned { get; set; }

    public string? OwnedOn { get; set; }

    public bool Finished { get; set; }
}
