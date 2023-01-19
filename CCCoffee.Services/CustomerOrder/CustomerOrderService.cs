using CCCoffee.Data;
using CCCoffee.Data.Entities;
using CCCoffee.Models.CustomerOrder;
using Microsoft.EntityFrameworkCore;

namespace CCCoffee.Services.CustomerOrder
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ApplicationDbContext _context;
        public CustomerOrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCustomerOrderAsync(CustomerOrderCreate order)
        {
            var customerOrderEntity = new CustomerOrderEntity
            {
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
                MenuItemId = order.MenuItemId
            };

            _context.CustomerOrders.Add(customerOrderEntity);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<CustomerOrderListItem>> GetAllOrdersAsync()
        {
            var orders = await _context.CustomerOrders
            .Include(entity => entity.Customer)
            .Include(entity => entity.MenuItem)
            .Select(entity => new CustomerOrderListItem
            {
                OrderId = entity.OrderId,
                OrderDate = entity.OrderDate,
                CustomerFirstName = entity.Customer.FirstName,
                CustomerLastName = entity.Customer.LastName,
                MealName = entity.MenuItem.MealName
            })
            .ToListAsync();

            return orders;
        }
        public async Task<IEnumerable<CustomerOrderDetail>> GetOrdersByIdAsync(int orderId)
        {
            // var customerOrderEntity = await _context.CustomerOrders
            // .FirstOrDefaultAsync(e => e.OrderId == orderId);

            // return customerOrderEntity is null ? null : 
            var customerOrderEntity = await _context.CustomerOrders
            .Include(customerOrderEntity => customerOrderEntity.Customer)
            .Include(customerOrderEntity => customerOrderEntity.MenuItem)
            .Select(customerOrderEntity => new CustomerOrderDetail
            {
                OrderId = customerOrderEntity.OrderId,
                OrderDate = customerOrderEntity.OrderDate,
                CustomerFirstName = customerOrderEntity.Customer.FirstName,
                CustomerLastName = customerOrderEntity.Customer.LastName,
                MealName = customerOrderEntity.MenuItem.MealName
            }).ToListAsync();

            return customerOrderEntity;
        }
        // public async Task<bool> UpdateOrderAsync(CustomerOrderUpdate order)
        // {
        //     var customerOrderEntity = await _context.CustomerOrders.FindAsync(order.OrderId);

        //     customerOrderEntity.OrderDate = order.OrderDate;

        //     var numberOfChanges = await _context.SaveChangesAsync();

        //     return numberOfChanges == 1;
        // }
        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var customerOrderEntity = await _context.CustomerOrders.FindAsync(orderId);

            _context.CustomerOrders.Remove(customerOrderEntity);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}