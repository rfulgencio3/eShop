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
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productDTO = await _productService.GetProducts();
            if (productDTO is null) return StatusCode(404, "PRODUCTS_NOT_FOUND");

            return StatusCode(200, productDTO);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var productDTO = await _productService.GetProductById(id);
            if (productDTO is null) return StatusCode(404, $"PRODUCT_{id}_NOT_FOUND");

            return StatusCode(200, productDTO);
        }

        [HttpGet("{name}", Name = "GetProductByName")]
        public async Task<ActionResult<ProductDTO>> Get(string name)
        {
            var productDTO = await _productService.GetProductByName(name);
            if (productDTO is null) return StatusCode(404, $"PRODUCT{name.ToUpper()}_NOT_FOUND");

            return StatusCode(200, productDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null) return StatusCode(400, "INVALID_DATA");

            await _productService.AddProduct(productDTO);

            return new CreatedAtRouteResult("GetProductById", new { id = productDTO.ProductId }, productDTO);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null) return StatusCode(400, "INVALID_DATA");

            await _productService.UpdateProduct(productDTO);

            return StatusCode(202, productDTO);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDTO = await _productService.GetProductById(id);

            if (productDTO is null) return StatusCode(404, $"PRODUCT_{id}_NOT_FOUND");

            await _productService.RemoveProduct(id);
            return StatusCode(204);
        }
    }
}