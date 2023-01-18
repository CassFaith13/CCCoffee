using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CCCoffee.Models.MenuModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CCCoffee.WebAPI.MenuController
{
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuServices _MenuService;

        public MenuController(IMenuServices menuService)
        {
            _MenuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _MenuService.GetMenuItemEntity());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _MenuService.GetMenuItemById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuCreate model )
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(await _MenuService.AddMenu(model))
                return Ok("Success");
            else
                return UnprocessableEntity();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MenuEdit model)
        {
            if(id!= model.Id) return BadRequest("Invalid Id");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(await _MenuService.UpdateMenu(id,model))
                return Ok("Success");
            else
                return UnprocessableEntity();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _MenuService.DeleteMenu(id))
                return Ok("Success");
            else
                return UnprocessableEntity();
        }
    }
}