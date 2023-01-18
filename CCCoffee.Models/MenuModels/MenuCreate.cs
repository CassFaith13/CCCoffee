using System.ComponentModel.DataAnnotations;

public class MenuCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Meal name cannot exceed 50 characters!")]
        public string? MealName { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Meal description cannot exceed 150 characters!")]
        public string? MealDescription { get; set; }
        [Required]
        public decimal MealPrice { get; set; }
    }
