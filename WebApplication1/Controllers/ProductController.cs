using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Interfaces.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet("AllProduct")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAllProducts() {
        return Ok(await _service.GetAllProductAsync());
        
        }
        [HttpGet("Product")]

        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProduct(int id)
        {
            return Ok(await _service.GetProductAsync(id));

        }
        [HttpPost]
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(ProductToReturnDto productdTo)
        {
            try
            {
                if (productdTo == null)
                    return BadRequest();

                await _service.AddAsync(productdTo);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Product record");
            }
        }


    }
}
