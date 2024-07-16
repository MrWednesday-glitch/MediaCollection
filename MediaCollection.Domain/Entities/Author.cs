namespace MediaCollection.Domain.Entities;

public class Author : EntityBase
{
    public Author()
    {
        Books = new List<Book>();
    }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Book> Books { get; set; }
}
