using DesafioSML.Models;
using DesafioSML.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSML.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceIService invoiceService;

        public InvoiceController(InvoiceIService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvoice(InvoiceCreateModel invoiceModel)
        {
            if (!await invoiceService.CreateInvoice(invoiceModel))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
