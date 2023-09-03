using DesafioSML.Data;

namespace DesafioSML.Repository.IRepository
{
    public interface CustomerIRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<int> InsertCostumer(Customer customer);
    }
}
