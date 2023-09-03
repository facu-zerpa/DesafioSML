using DesafioSML.Data;
using DesafioSML.Models;
using DesafioSML.Repository.IRepository;
using DesafioSML.Services.IServices;

namespace DesafioSML.Services
{
    public class InvoiceService : InvoiceIService
    {
        private readonly InvoiceIRepository invoiceIRepository;
        private readonly InvoiceItemIRepository invoiceItemIRepository;

        public InvoiceService(InvoiceIRepository invoiceIRepository, InvoiceItemIRepository invoiceItemIRepository)
        {
            this.invoiceIRepository = invoiceIRepository;
            this.invoiceItemIRepository = invoiceItemIRepository;
        }
        public async Task<bool> CreateInvoice(InvoiceCreateModel invoiceModel)
        {
            Invoice invoice = new Invoice { Date = invoiceModel.Date, CustomerId = invoiceModel.CustomerId };
            int invoiceId = await invoiceIRepository.InsertInvoice(invoice);

            if (invoiceId == -1)
            {
                return false;
            }

            List<InvoiceItem> invoicesItems = new List<InvoiceItem>();

            foreach (string code in invoiceModel.Codes)
            {
                InvoiceItem invoiceItem = new InvoiceItem { InvoiceId = invoiceId, ProductCode = code };
                invoicesItems.Add(invoiceItem);
            }

            return await invoiceItemIRepository.InsertInvoicesItems(invoicesItems) > 0 ? true : false;

        }
    }
}
