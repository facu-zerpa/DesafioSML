using AutoMapper;
using DesafioSML.Data;
using DesafioSML.Models;
using DesafioSML.Models.DTO;
using DesafioSML.Repository.IRepository;
using DesafioSML.Services.IServices;

namespace DesafioSML.Services
{
    public class CustomerService : CustomerIService
    {
        private readonly CustomerIRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(CustomerIRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateCustomer(CustomerCreateModel customerModel)
        {
            Customer customer = new Customer 
                                    { 
                                        FirstName = customerModel.FirstName, 
                                        LastName = customerModel.LastName, 
                                        Address = customerModel.Address 
                                    };

            return await customerRepository.InsertCostumer(customer) > 0 ? true : false;
        }

        public async Task<List<CustomerCreateDTO>> GetAllCustomers()
        {
            List<Customer> customers = await customerRepository.GetAllCustomers();
            List<CustomerCreateDTO> customersDTO = mapper.Map<List<CustomerCreateDTO>>(customers);
            return customersDTO;
        }
    }
}
