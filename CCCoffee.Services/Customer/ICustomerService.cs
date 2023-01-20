using CCCoffee.Models.CustomerModels;

namespace CCCoffee.Services.Customer
{
    // crud methods go here... and a lot of times other methods as well. THIS IS JUST THE CONTRACT.
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(CustomerCreate customer);
        Task<IEnumerable<CustomerListItem>> GetCustomersAsync();
        Task<CustomerDetail> GetCustomerByIdAsync(int customerId);
        // Task<CustomerDetail>GetCustomerByNameAsync(string customerName);
        // Task<bool> UpdateCustomerAsync(int customerId, CustomerEdit customerEdit);
        Task<bool> DeleteCustomerAsync(int customerId);
    }
}