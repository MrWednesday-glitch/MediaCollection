namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Film : Media
{
    public Guid DirectorId { get; set; }

    public virtual Director Director { get; set; } = null!;
}
