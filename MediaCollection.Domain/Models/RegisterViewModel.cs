using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Domain.Models;

public class RegisterViewModel
{
    [Required]
    [Display(Name = "First Name")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Last Name")]
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email Id is Required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
