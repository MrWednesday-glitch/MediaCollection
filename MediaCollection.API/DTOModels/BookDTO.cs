namespace MediaCollection.API.DTOModels;

public class BookDTO
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string PublisherName { get; set; } = string.Empty;

    public string ReleaseDate { get; set; } = string.Empty;

    public string AuthorName { get; set; } = string.Empty;
}
