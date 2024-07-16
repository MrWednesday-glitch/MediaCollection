namespace MediaCollection.Domain.Entities;

public class Book : Media
{
    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!
}
