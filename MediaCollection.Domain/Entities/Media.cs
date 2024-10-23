namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Media : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public Guid PublisherId { get; set; }

    public virtual Publisher Publisher { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public bool Owned { get; set; }
}
