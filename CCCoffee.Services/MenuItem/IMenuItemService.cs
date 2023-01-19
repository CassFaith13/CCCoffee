using CCCoffee.Models.Menu;
using CCCoffee.Models.MenuModels;

namespace CCCoffee.Services.MenuItem
{
    public interface IMenuItemService
    {
        Task<bool> AddMenuAsync(MealCreate model);
        Task<MealDetail> GetMenuItemByIdAsync(int menuItemId);
        Task<IEnumerable<MenuList>> GetAllMenuItemsAsync();
        Task<bool> UpdateMenuAsync(int menuItemId, MealEdit model);
        Task<bool> DeleteMenuAsync(int menuItemId);
    }
}