using EfWithWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfWithWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context, ProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }
        [HttpGet("product-list")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _context.Products.ToListAsync();
            return Ok(result);
        }
        [HttpGet("productWithCategory-list")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            var result = await _productRepository.GetProductListWithCategory();
            return Ok(result);
        }
        [HttpGet("productlist-byCategoryName/{categoryName}")]
        public async Task<IActionResult> GetAllProductsByCategoryName([FromRoute] string categoryName)
        {
            await Task.Delay(2000);
            var result = await _productRepository.GetProductListWithCategoryByCategoryName(categoryName);
            return Ok(result);
        }
    }
}
