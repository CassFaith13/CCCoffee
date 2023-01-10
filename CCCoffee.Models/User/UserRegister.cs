using System.ComponentModel.DataAnnotations;

namespace CCCoffee.Models.User
{
    public class UserRegister
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(4)]
        public string? Username { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}