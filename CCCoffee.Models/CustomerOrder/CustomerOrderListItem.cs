using CCCoffee.Models.Customer;
using CCCoffee.Models.MenuItem;

namespace CCCoffee.Models.CustomerOrder
{
    public class CustomerOrderListItem
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public ICollection<CustomerListItem> Customer { get; } = new List<CustomerListItem>();
        public ICollection<MenuItemListItem> MenuItems { get; } = new List<MenuItemListItem>();
    }
}