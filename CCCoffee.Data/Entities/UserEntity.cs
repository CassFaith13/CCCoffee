using System.ComponentModel.DataAnnotations;

namespace CCCoffee.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}