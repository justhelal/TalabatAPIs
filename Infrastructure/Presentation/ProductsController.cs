using Microsoft.AspNetCore.Mvc;
using Service.Abstraction;
using Shared.Dtos;
using Shared.QueryParams;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery] ProductQueryParams queryParams)
        {
            var products = await serviceManager.ProductService.GetAllAsync(queryParams);
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await serviceManager.ProductService.GetByIdAsync(id);
            return Ok(product);
        }
    }
}