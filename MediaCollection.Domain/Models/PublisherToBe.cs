namespace MediaCollection.Domain.Models;

/// <summary>
/// The model for information that will become a <see cref="Publisher"/> entity.
/// </summary>
public record PublisherToBe
{
    /// <summary>
    /// An uri to a picture.
    /// </summary>
    public string? PictureUri { get; init; }

    /// <summary>
    /// The name of the <see cref="Publisher"/>.
    /// </summary>
    public string Name { get; init; } = string.Empty;
}
