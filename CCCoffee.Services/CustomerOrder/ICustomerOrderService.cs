using CCCoffee.Models.CustomerOrder;

namespace CCCoffee.Services.CustomerOrder
{
    public interface ICustomerOrderService
    {
        Task<bool> CreateCustomerOrderAsync(CustomerOrderCreate order);
        Task<IEnumerable<CustomerOrderListItem>> GetAllOrdersAsync();
        Task<IEnumerable<CustomerOrderDetail>> GetOrdersByIdAsync(int orderId);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
