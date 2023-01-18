using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCCoffee.Models.Menu
{
    public class MenuItem
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
