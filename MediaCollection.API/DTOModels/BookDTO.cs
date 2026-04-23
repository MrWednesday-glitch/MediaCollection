namespace MediaCollection.API.DTOModels;

[ExcludeFromCodeCoverage]
public record BookDTO
{
    public Guid Id { get; init; }

    [Required]
    public string Name { get; init; } = string.Empty;

    public string PublisherName { get; init; } = string.Empty;

    public string ReleaseDate { get; init; } = string.Empty;

    public string AuthorName { get; init; } = string.Empty;

    public string? PictureUri { get; init; }
}
