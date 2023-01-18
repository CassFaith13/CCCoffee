using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class MenuCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Sorry you can only have 50 characters")]
        public string? MealName { get; set; }
        [Required]
        public int MealDescription { get; set; }
        [Required]
        public string? MealPrice { get; set; }
        
    }
