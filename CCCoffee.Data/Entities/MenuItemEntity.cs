using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCCoffee.Data.Entities
{
    public class MenuItemEntity
    {
        [Key]
        public int MenuItemId { get; set; }
        [Required]
        public string? MealName { get; set; }
        [Required]
        public string? MealDescription { get; set; }
        [Required]
        public decimal MealPrice { get; set; }
    } 
}