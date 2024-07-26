using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskk.Core;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites;
using Taskk.Core.Interfaces.Services;

namespace WebApplication1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<CustomerToReturnDto>>> GetAllCustomerAsync([FromQuery]CustomerSpecificationParameter parameter) =>
            Ok(await _service.GetAllCustomerAsync(parameter));
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerToReturnDto>> GetCustomerAsync(int id) =>
            Ok(await _service.GetCustomerAsync(id));
        [HttpGet("CustomerOrder")]
        public async Task<ActionResult<IEnumerable<OrderItemToReturnDto>>> GetAllCustomerOrderAsync() =>
            Ok(await _service.GetAllCustomerOrderAsync());
        [HttpPost]
        public async Task<ActionResult<CustomerToReturnDto>> CreateCustomer(CustomerToReturnDto customerDto)
        {
            try
            {
                if (customerDto == null)
                 return BadRequest(); 

                 await _service.AddAsync(customerDto);

               return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Customer record");
            }
        }

    }
}
