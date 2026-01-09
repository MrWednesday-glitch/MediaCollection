namespace MediaCollection.Domain.Models;

/// <summary>
/// The model for information that will become a <see cref="Developer"/> entity.
/// </summary>
public record DeveloperToBe
{
    /// <summary>
    /// An uri to a picture.
    /// </summary>
    public string? PictureUri { get; init; }

    /// <summary>
    /// The name of the <see cref="Developer"/>.
    /// </summary>
    public string Name { get; init; } = string.Empty;
}
