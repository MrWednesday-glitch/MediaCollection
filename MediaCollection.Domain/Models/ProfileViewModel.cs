namespace MediaCollection.Domain.Models;

public class ProfileViewModel
{
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public DateTime? LastLoggedIn { get; set; }
    public DateTime? CreatedOn { get; set; }
}
