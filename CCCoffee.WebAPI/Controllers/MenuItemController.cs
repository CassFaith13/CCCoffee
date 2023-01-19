using CCCoffee.Models.Menu;
using CCCoffee.Models.MenuModels;
using CCCoffee.Services.MenuItem;
using Microsoft.AspNetCore.Mvc;

namespace CCCoffee.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuService;
        public MenuItemController(IMenuItemService menuService)
        {
            _menuService = menuService;
        }
        [HttpPost]
        public async Task<IActionResult> AddMenu([FromForm] MealCreate meal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _menuService.AddMenuAsync(meal))
            {
                return Ok("Menu Item created successfully!");
            }
            return BadRequest("Unable to create MenuItem.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var meals = await _menuService.GetAllMenuItemsAsync();

            return Ok(meals);
        }
        [HttpGet, Route("{menuItemId}")]
        public async Task<IActionResult> GetMenuItemById(int menuItemId)
        {
            var detail = await _menuService.GetMenuItemByIdAsync(menuItemId);

            if (detail is null)
            {
                return NotFound();
            }
            return Ok(detail);
        }
        [HttpPut, Route("{menuItemId}")]
        public async Task<IActionResult> UpdateMenu(int menuItemId, MealEdit model)
        {
            if (await _menuService.UpdateMenuAsync(menuItemId, model))
            {
                return Ok("Menu Item was successfully updated.");
            }
            return BadRequest("Unable to update Menu Item.");
        }
        [HttpDelete, Route("{menuItemId}")]
        public async Task<IActionResult> DeleteMenu(int menuItemId)
        {
            if (await _menuService.DeleteMenuAsync(menuItemId))
            {
                return Ok("Menu Item was successfully deleted.");
            }
            return BadRequest("Unable to delete Menu Item.");
        }
    }
}