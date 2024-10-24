namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class EntityBase
{
    public Guid Id { get; set; }

    public string? PictureUri { get; set; }
}
