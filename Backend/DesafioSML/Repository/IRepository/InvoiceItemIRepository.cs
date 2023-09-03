using DesafioSML.Data;

namespace DesafioSML.Repository.IRepository
{
    public interface InvoiceItemIRepository
    {
        Task<int> InsertInvoicesItems(List<InvoiceItem> invoicesItems);
    }
}
