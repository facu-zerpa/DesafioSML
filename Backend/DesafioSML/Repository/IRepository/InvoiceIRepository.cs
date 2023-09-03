using DesafioSML.Data;

namespace DesafioSML.Repository.IRepository
{
    public interface InvoiceIRepository
    {
        Task<int> InsertInvoice(Invoice invoice);
    }
}
