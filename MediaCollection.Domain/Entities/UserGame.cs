using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class UserGame
{
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;

    [Required]
    public Guid GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public virtual Game Game { get; set; } = null!;

    public bool Owned { get; set; }

    public bool Finished { get; set; }

    public string? OwnedOn { get; set; }
}
