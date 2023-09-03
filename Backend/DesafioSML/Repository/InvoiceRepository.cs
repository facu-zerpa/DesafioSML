using DesafioSML.Data;
using DesafioSML.Repository.IRepository;

namespace DesafioSML.Repository
{
    public class InvoiceRepository : InvoiceIRepository
    {
        private readonly ApplicationDbContext db;

        public InvoiceRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> InsertInvoice(Invoice invoice)
        {
            try
            {
                await db.AddAsync(invoice);
                await db.SaveChangesAsync();
                return invoice.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
