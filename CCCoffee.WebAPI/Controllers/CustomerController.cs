using CCCoffee.Models.CustomerModels;
using CCCoffee.Services.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CCCoffee.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _service.CreateCustomerAsync(customer))
            {
            return Ok("Customer successfully created.");
            }
            return BadRequest("Internal Server Error.");
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _service.GetCustomersAsync();

            return Ok(customers);
        }

        [HttpGet, Route("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var detail = await _service.GetCustomerByIdAsync(customerId);
            
            if (detail is null)
            {
                return NotFound();
            }
            return Ok(detail);
        }
        [HttpDelete, Route("{customerId}")]
        public async Task<IActionResult> DeleteCustomerOrder(int customerId)
        {
            if (await _service.DeleteCustomerAsync(customerId))
            {
                return Ok("Customer was successfully deleted.");
            }
            return BadRequest("Unable to delete Customer.");
        }
    }
}