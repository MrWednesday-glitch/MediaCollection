namespace MediaCollection.API.DTOModels;

public class FilmDTO
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string PublisherName { get; set; } = string.Empty;

    public string ReleaseDate { get; set; } = string.Empty;

    public string DirectorName { get; set; } = string.Empty;
}
