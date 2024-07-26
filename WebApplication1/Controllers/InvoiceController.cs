using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskk.Core.DataTransferObjects;
using Taskk.Core.Interfaces.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;
        public InvoiceController(IInvoiceService service)
        {
            _service = service;

        }
        [HttpGet("AllInvoices")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAllInvoices()
        {
            return Ok(await _service.GetAllInvoicesAsync());

        }
        [HttpGet("Invoice")]

        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetInvoice(int id)
        {
            return Ok(await _service.GetInvoiceAsync(id));

        }



    }
}
