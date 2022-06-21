using eShop.ProductAPI.DTOs;
using eShop.ProductAPI.Roles;
using eShop.ProductAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDTO = await _categoryService.GetCategories();
            if (categoriesDTO is null) return StatusCode(404, "CATEGORIES_NOT_FOUND");

            return StatusCode(200, categoriesDTO);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryProducts()
        {
            var categoriesProductsDTO = await _categoryService.GetCategoriesProducts();
            if (categoriesProductsDTO is null) return StatusCode(404, "CATEGORIES_PRODUCTS_NOT_FOUND");

            return StatusCode(200, categoriesProductsDTO);
        }
        
        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDTO = await _categoryService.GetCategoryById(id);
            if (categoryDTO is null) return StatusCode(404, $"CATEGORY_{id}_NOT_FOUND");

            return StatusCode(200,categoryDTO);
        }

        [HttpGet("{name}", Name = "GetCategoryByName")]
        public async Task<ActionResult<CategoryDTO>> Get(string name)
        {
            var categoryDTO = await _categoryService.GetCategoryByName(name);
            if (categoryDTO is null) return StatusCode(404, $"CATEGORY_{name.ToUpper()}_NOT_FOUND");

            return StatusCode(200, categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO is null) return StatusCode(400, "INVALID_DATA");

            await _categoryService.AddCategory(categoryDTO);

            return new CreatedAtRouteResult("GetCategoryById", new { id = categoryDTO.CategoryId }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId) return StatusCode(400, "INVALID_CATEGORY_ID");
            if (categoryDTO is null) return StatusCode(400, "INVALID_DATA");

            await _categoryService.UpdateCategory(categoryDTO);

            return StatusCode(202,categoryDTO);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDTO = await _categoryService.GetCategoryById(id);

            if (categoryDTO is null) return StatusCode(404, $"CATEGORY_{id}_NOT_FOUND");

            await _categoryService.RemoveCategory(id);
            return StatusCode(204);
        }
    }
}
