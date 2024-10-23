namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Book : Media
{
    public Guid AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;
}
