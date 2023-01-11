using CCCoffee.Data.Entities;
using CCCoffee.Models.CustomerModels;
using CCCoffee.Models.MenuItem;

namespace CCCoffee.Models.CustomerOrder
{
    public class CustomerOrderListItem
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerEntity FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? MealName { get; set; } = null!;
    }
}