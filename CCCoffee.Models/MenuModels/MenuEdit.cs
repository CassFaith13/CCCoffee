using System.ComponentModel.DataAnnotations;

namespace CCCoffee.Models.Menu
{
    public class MenuCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Sorry you can only have 50 characters")]
        public string? MealName { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Meal Name cannot exceed 150 characters!")]
        public string? MealDescription { get; set; }
        [Required]
        public decimal MealPrice { get; set; }
        
    }
}
