// using CCCoffee.Data;
// using CCCoffee.Data.Entities;
// using CCCoffee.Models.CustomerOrder;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;

// namespace CCCoffee.Services.CustomerOrder
// {
//     public class CustomerOrderService : ICustomerOrderService
//     {
//         private readonly ApplicationDbContext _context;
//         public CustomerOrderService(ApplicationDbContext context)
//         {
//             _context = context;
//         }
//         public async Task<bool> CreateCustomerOrderAsync(CustomerOrderCreate order)
//         {
//             var customerOrderEntity = new CustomerOrderEntity
//             {
//                 OrderDate = order.DateTimeOffset.Now,

//             };

//             _context.CustomerOrders.Add(customerOrderEntity);

//             var numberOfChanges = await _context.SaveChangesAsync();
//             return numberOfChanges == 1;
//         }

//         public async Task<IEnumerable<CustomerOrderListItem>> GetAllOrdersAsync()
//         {
//             var orders = await _context.CustomerOrders
//             .Select(entity => new CustomerOrderListItem
//             {
//                 OrderId = entity.OrderId,
//                 OrderDate = entity.OrderDate
//             })
//             .ToListAsync();

//             return orders;
//         }
//         public async Task<CustomerOrderDetail?> GetOrderByIdAsync(int orderId)
//         {
//             var customerOrderEntity = await _context.CustomerOrders
//             .FirstOrDefaultAsync(e => e.OrderId == orderId);

//             return customerOrderEntity is null ? null : new CustomerOrderDetail
//             {
//                 OrderId = customerOrderEntity.OrderId,
//                 OrderDate = customerOrderEntity.OrderDate
//             };
//         }
//         public async Task<bool> UpdateOrderAsync(CustomerOrderUpdate order)
//         {
//             var customerOrderEntity = await _context.CustomerOrders.FindAsync(order.OrderId);

//             customerOrderEntity.OrderDate = order.OrderDate;

//             var numberOfChanges = await _context.SaveChangesAsync();

//             return numberOfChanges == 1;
//         }
//         public async Task<bool> DeleteOrderAsync(int orderId)
//         {
//             var customerOrderEntity = await _context.CustomerOrders.FindAsync(orderId);

//             _context.CustomerOrders.Remove(customerOrderEntity);

//             return await _context.SaveChangesAsync() == 1;
//         }
//     }
// }