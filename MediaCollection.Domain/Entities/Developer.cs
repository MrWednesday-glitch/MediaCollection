namespace MediaCollection.Domain.Entities;

public class Developer : EntityBase
{
    public Developer()
    {
        Games = new List<Game>();
    }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Game> Games { get; set; }
}
