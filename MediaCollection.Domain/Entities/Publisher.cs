namespace MediaCollection.Domain.Entities;

public class Publisher : EntityBase
{
    public Publisher()
    {
        Games = new List<Game>();
    }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Game> Games { get; set; }
}
