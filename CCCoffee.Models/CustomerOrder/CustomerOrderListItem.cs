using CCCoffee.Data.Entities;

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