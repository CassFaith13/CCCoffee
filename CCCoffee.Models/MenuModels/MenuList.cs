using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCCoffee.Models.MenuModels
{
    public class MenuList
    {
        public int MenuItemId { get; set; }
        public string? MealName { get; set; }
        public decimal MealPrice { get; set; }
    }
}
