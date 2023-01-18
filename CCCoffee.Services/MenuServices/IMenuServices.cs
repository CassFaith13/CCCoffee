using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCCoffee.Models.MenuModels;


    public interface IMenuServices
    {
       Task<bool> AddMenu(MenuCreate model);
       Task<bool> UpdateMenu(int id, MenuEdit model);
       Task<bool> DeleteMenu(int id);
       Task<MenuDetail> GetMenuItemById(int id);
       Task<List<MenuList>> GetMenuItemEntity();
      
    }

    
