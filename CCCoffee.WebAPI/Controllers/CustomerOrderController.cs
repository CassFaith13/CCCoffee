using CCCoffee.Models.CustomerOrder;
using CCCoffee.Services.CustomerOrder;
using Microsoft.AspNetCore.Mvc;

namespace CCCoffee.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _orderService;
        public CustomerOrderController(ICustomerOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomerOrder([FromForm] CustomerOrderCreate order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _orderService.CreateCustomerOrderAsync(order))
            {
                return Ok("Customer Order created successfully!");
            }
            return BadRequest("Unable to create Customer Order.");
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            return Ok(orders);
        }
        [HttpGet, Route("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var detail = await _orderService.GetOrdersByIdAsync(orderId);
            
            if (detail is null)
            {
                return NotFound();
            }
            return Ok(detail);
        }
        [HttpDelete, Route("{orderId}")]
        public async Task<IActionResult> DeleteCustomerOrder(int orderId)
        {
            if (await _orderService.DeleteOrderAsync(orderId))
            {
                return Ok("Customer Order was successfully deleted.");
            }
            return BadRequest("Unable to delete Customer Order.");
        }
    }
}