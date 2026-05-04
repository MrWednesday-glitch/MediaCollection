using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCollection.Domain.Entities;

[ExcludeFromCodeCoverage]
public class UserBook
{
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;

    [Required]
    public Guid BookId { get; set; }

    [ForeignKey(nameof(BookId))]
    public virtual Book Book { get; set; } = null!;

    public bool Owned { get; set; }
}
