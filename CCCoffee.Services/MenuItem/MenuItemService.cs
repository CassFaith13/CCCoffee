using CCCoffee.Data;
using CCCoffee.Data.Entities;
using CCCoffee.Models.Menu;
using CCCoffee.Models.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace CCCoffee.Services.MenuItem
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ApplicationDbContext _context;

        public MenuItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMenuAsync(MealCreate model)
        {
            var menuItemEntity = new MenuItemEntity
            {
                MealName = model.MealName,
                MealDescription = model.MealDescription,
                MealPrice = model.MealPrice
            };
            _context.MenuItems.Add(menuItemEntity);

            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<MealDetail?> GetMenuItemByIdAsync(int menuItemId)
        {
            var menuItemEntity = await _context.MenuItems.FirstOrDefaultAsync(e => e.MenuItemId == menuItemId);

            if (menuItemEntity is null)
                return null;

            return new MealDetail
            {
                MealName = menuItemEntity.MealName,
                MealDescription = menuItemEntity.MealDescription,
                MealPrice = menuItemEntity.MealPrice
            };
        }

        public async Task<IEnumerable<MenuList>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.Select(b => new MenuList
            {
                MenuItemId = b.MenuItemId,
                MealName = b.MealName,
                MealPrice = b.MealPrice
            }).ToListAsync();
        }

        public async Task<bool> UpdateMenuAsync(int menuItemId, MealEdit model)
        {
            var menuItemEntity = await _context.MenuItems.FindAsync(menuItemId);

            if (menuItemEntity is null)
                return default;

            menuItemEntity.MealName = model.MealName;
            menuItemEntity.MealDescription = model.MealDescription;
            menuItemEntity.MealPrice = model.MealPrice;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMenuAsync(int menuItemId)
        {
            var menuItemEntity = await _context.MenuItems.FirstOrDefaultAsync(e => e.MenuItemId == menuItemId);

            if (menuItemEntity is null)
                return default;

            _context.MenuItems.Remove(menuItemEntity);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}