using DesafioSML.Data;
using DesafioSML.Models;
using DesafioSML.Models.DTO;
using DesafioSML.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSML.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerIService customerService;

        public CustomerController(CustomerIService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerCreateDTO>>> GetAllCustomer()
        {
            List<CustomerCreateDTO> customers = await customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerCreateModel customerModel)
        {
            if (await customerService.CreateCustomer(customerModel))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
