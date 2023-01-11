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
        public CustomerEntity LastName { get; set; } = null!;
        public MenuItemEntity MealName { get; set; } = null!;
    }
}