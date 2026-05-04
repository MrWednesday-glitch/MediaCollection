namespace MediaCollection.API.DTOModels;

[ExcludeFromCodeCoverage]
public record FilmDTO
{
    public Guid Id { get; init; }

    [Required]
    public string Name { get; init; } = string.Empty;

    public string PublisherName { get; init; } = string.Empty;

    public string ReleaseDate { get; init; } = string.Empty;

    public string DirectorName { get; init; } = string.Empty;

    public string? PictureUri { get; init; }
}
