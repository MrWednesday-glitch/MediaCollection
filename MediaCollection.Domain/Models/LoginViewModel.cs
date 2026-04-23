using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Domain.Models;

[ExcludeFromCodeCoverage]
public class LoginViewModel
{
    [Required(ErrorMessage = "Email Id is Required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password Id is Required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }
}
