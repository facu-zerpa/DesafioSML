using DesafioSML.Data;
using DesafioSML.Repository.IRepository;

namespace DesafioSML.Repository
{
    public class InvoiceItemRepository : InvoiceItemIRepository
    {
        private readonly ApplicationDbContext db;

        public InvoiceItemRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> InsertInvoicesItems(List<InvoiceItem> invoicesItems)
        {
            await db.AddRangeAsync(invoicesItems);
            return await db.SaveChangesAsync();
        }
    }
}
