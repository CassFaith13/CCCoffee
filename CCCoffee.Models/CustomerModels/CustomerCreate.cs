using System.ComponentModel.DataAnnotations;

namespace CCCoffee.Models.CustomerModels
{
    public class CustomerCreate
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime CustomerBirthday { get; set; }
    }
}