using Microsoft.AspNetCore.Mvc;
using QrMenu.Application.Interfaces;
using QrMenu.Domain.Entities;

namespace QrMenu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAll()
        {
            var items = await _menuService.GetMenuItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetById(int id)
        {
            var item = await _menuService.GetMenuItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetByCategory(int categoryId)
        {
            var items = await _menuService.GetMenuItemsByCategoryIdAsync(categoryId);
            if (items == null || !items.Any())
            {
                return NotFound($"Kategori {categoryId} için menü item bulunamadı.");
            }

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> Create(MenuItem item)
        {
            await _menuService.AddMenuItemAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
    }
}
