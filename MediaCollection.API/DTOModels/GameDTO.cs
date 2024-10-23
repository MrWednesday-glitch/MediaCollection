using System.ComponentModel.DataAnnotations;

namespace MediaCollection.API.DTOModels;

public class GameDTO
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string PublisherName { get; set; } = string.Empty;

    public string ReleaseDate { get; set; } = string.Empty;

    public bool Owned { get; set; }

    public string DeveloperName { get; set; } = string.Empty;

    public string OwnedOn { get; set; } = string.Empty;

    public bool Finished { get; set; }
}
