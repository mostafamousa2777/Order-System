using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Entites;
using Taskk.Core.Interfaces.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [Authorize(AuthenticationSchemes = "Bearer",Roles ="Admin")]
        [HttpGet("AllOrders")]
        
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetAllOrders() 
            => Ok(await _service.GetAllOrderAsync());
        [HttpGet("Order")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrder(int id) 
            => Ok(await _service.GetOrderAsync(id));
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderToReturnDto orderdto)
        {
            try
            {
                if (orderdto == null)
                    return BadRequest();

                await _service.AddAsync(orderdto);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Order record");
            }
        }
    }
}
