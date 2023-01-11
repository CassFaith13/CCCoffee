using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CCCoffee.Models.CustomerOrder
{
    public class CustomerOrderCreate
    {
        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Menu Item ID")]
        public int MenuItemId { get; set; }
    }
}