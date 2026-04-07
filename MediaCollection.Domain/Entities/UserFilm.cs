using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Domain.Entities;

public class UserFilm
{
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;

    [Required]
    public Guid FilmId { get; set; }

    [ForeignKey(nameof(FilmId))]
    public virtual Film Film { get; set; } = null!;

    public bool Owned { get; set; }
}
