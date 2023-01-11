using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCCoffee.Data;
using CCCoffee.Data.Entities;
using CCCoffee.Models.CustomerModels;
using CCCoffee.Services;

namespace CCCoffee.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCustomerAsync(CustomerCreate customer)
        {
            var customerEntity =new CustomerEntity
            {
                ProfileCreated = DateTime.Now,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CustomerBirthday = customer.CustomerBirthday
            };

            _context.Customers.Add(customerEntity);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges ==1;

            // return _context.SaveChangesAsync()>0;
        }

        public Task<bool> DeleteCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDetail> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDetail> GetCustomerByNameAsync(string customerName)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerListItem> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomerAsync(int customerId, CustomerEdit customerEdit)
        {
            throw new NotImplementedException();
        }
    }

}
