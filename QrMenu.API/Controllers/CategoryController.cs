using Microsoft.AspNetCore.Mvc;
using QrMenu.Domain.Entities;
using QrMenu.Infrastructure.Repository;

namespace QrMenu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            await _categoryRepository.AddAsync(category);
            return CreatedAtAction(nameof(GetAll), category);
        }
    }
}
