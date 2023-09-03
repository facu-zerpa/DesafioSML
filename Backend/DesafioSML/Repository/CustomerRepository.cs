using DesafioSML.Data;
using DesafioSML.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DesafioSML.Repository
{
    public class CustomerRepository : CustomerIRepository
    {
        private readonly ApplicationDbContext db;

        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await db.Customers.ToListAsync();
        }

        public async Task<int> InsertCostumer(Customer customer)
        {
            await db.AddAsync(customer);
            return await db.SaveChangesAsync();
        }
    }
}
