using DesafioSML.Models;
using DesafioSML.Models.DTO;

namespace DesafioSML.Services.IServices
{
    public interface CustomerIService
    {
        Task<List<CustomerCreateDTO>> GetAllCustomers();
        Task<bool> CreateCustomer(CustomerCreateModel customerModel);
    }
}
