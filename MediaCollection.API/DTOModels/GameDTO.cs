namespace MediaCollection.API.DTOModels;

[ExcludeFromCodeCoverage]
public record GameDTO
{
    public Guid Id { get; init; }

    [Required]
    public string Name { get; init; } = string.Empty;

    public string PublisherName { get; init; } = string.Empty;

    public string ReleaseDate { get; init; } = string.Empty;

    public bool Owned { get; init; }

    public string DeveloperName { get; init; } = string.Empty;

    public string OwnedOn { get; init; } = string.Empty;

    public bool Finished { get; init; }

    public string? PictureUri { get; init; }
}
