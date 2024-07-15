namespace MediaCollection.Domain.Entities;

public class Publisher : EntityBase
{
    public Publisher()
    {
        Media = new List<Media>();
    }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Media> Media { get; set; } 
}
