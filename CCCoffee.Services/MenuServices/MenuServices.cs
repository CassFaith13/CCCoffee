using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCCoffee.Data;
using CCCoffee.Models.MenuModels;
using Microsoft.EntityFrameworkCore;

public class MenuServices : IMenuServices
{
    private readonly ApplicationDbContext _context;

    public MenuServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddMenu(MenuCreate model)
    {
        var MenuItemEntity = new MenuCreate
        {
            MealName = model.MealName,
            MealDescription = model.MealDescription,
            MealPrice = model.MealPrice
        };
        await _context.MenuItems.AddAsync(MenuCreate);
        return await _context.SaveChangesAsync() > 0;
        
    }

    public async Task<bool> DeleteMenu(int id)
    {
        var MenuItemEntity = await _context.MenuItems.FindAsync(id);
        if(MenuItemEntity is null) return default;

        _context.MenuItems.Remove(MenuItemEntity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<MenuDetail> GetMenuItemById(int id)
    {
        var MenuItemEntity = await _context.MenuItems.FindAsync(id);
        if(MenuItemEntity is null) return default;

        return new MenuDetail
        {
            MealName = MealName.id,
            MealDescription = MealDescription.id
        }; 
    }

    public async Task<List<MenuList>> GetMenuItemEntity()
    {
        return await _context.MenuItems.Select(b => new MenuList
        {
            MenuItemId = b.MenuItemId,
            MealName = b.MealName,
            MealPrice = b.MealPrice
        }).ToListAsync();
    }

    public async Task<bool> UpdateMenu(int id, MenuEdit model)
    {
        var MenuItemEntity = await _context.MenuItems.FindAsync(id);
        if(MenuItemEntity is null) return default;

        MenuItemEntity.MealName = model.MealName;
        MenuItemEntity.MealDescription = model.MealDescription;
        MenuItemEntity.MealPrice = model.MealPrice;

        return await _context.SaveChangesAsync() > 0;
    }
}
