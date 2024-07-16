namespace MediaCollection.Domain.Entities;

public class Director : EntityBase
{
    public Director()
    {
        Films = new List<Film>();
    }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Film> Films { get; set; }
}
