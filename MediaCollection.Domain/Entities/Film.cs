namespace MediaCollection.Domain.Entities;

public class Film : Media
{
    public int DirectorId { get; set; }

    public virtual Director Director { get; set; } = null!;
}
