using CCCoffee.Data;
using CCCoffee.Data.Entities;
using CCCoffee.Models.CustomerModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CCCoffee.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCustomerAsync(CustomerCreate model)
        {
            var customerEntity = new CustomerEntity
            {
                ProfileCreated = DateTime.Now,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CustomerBirthday = model.CustomerBirthday
            };

            _context.Customers.Add(customerEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<CustomerListItem>> GetCustomersAsync()
        {
            var customers = await _context.Customers.Select(entity => new CustomerListItem
            {
                CustomerId = entity.CustomerId,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            })
            .ToListAsync();

            return customers;
        }

        public async Task<CustomerDetail?> GetCustomerByIdAsync(int customerId)
        {
            var customerDetail = await _context.Customers.FirstOrDefaultAsync(e => e.CustomerId == customerId);

            return customerDetail is null ? null : new CustomerDetail
            {
                CustomerId = customerDetail.CustomerId,
                FirstName = customerDetail.FirstName,
                LastName = customerDetail.LastName,
                ProfileCreated = customerDetail.ProfileCreated,
                CustomerBirthday = customerDetail.CustomerBirthday
            };
        }

        // public async Task<CustomerDetail> GetCustomerByNameAsync(string )
        // {
        //     var customerDetail = await _context.Customers.FirstOrDefaultAsync(e => e.CustomerName == customerName);

        //     return customerDetail is null ? null : new CustomerDetail
        //     {
        //         CustomerId = customerDetail.CustomerId,
        //         FirstName = customerDetail.FirstName,
        //         LastName = customerDetail.LastName
        //     };
        // }
        

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customerEntity = await _context.Customers.FindAsync(customerId);

            _context.Customers.Remove(customerEntity);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}