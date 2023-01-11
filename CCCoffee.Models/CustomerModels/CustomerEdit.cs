using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCCoffee.Models.CustomerModels
{
    public class CustomerEdit
    {
        [Required]
        public string? CustomerId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime CustomerBirthday { get; set; }
    }
}