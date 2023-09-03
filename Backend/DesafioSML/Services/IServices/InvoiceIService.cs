using DesafioSML.Models;

namespace DesafioSML.Services.IServices
{
    public interface InvoiceIService
    {
        Task<bool> CreateInvoice(InvoiceCreateModel invoiceModel);
    }
}
