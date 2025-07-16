using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class CustomerViewModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; init; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; init; } = string.Empty;

        [Required]
        [Display(Name = "Email")]
        public string Email { get; init; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; init; }
    }
}
