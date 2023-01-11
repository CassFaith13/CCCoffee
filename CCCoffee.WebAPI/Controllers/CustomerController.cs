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
        public async Task<IActionResult> Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _service.CreateCustomerAsync(customer))
            return Ok("Success");
            else 
            return StatusCode(500,"Internal Server Error");
            
        }
    }
}