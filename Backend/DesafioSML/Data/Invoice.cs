using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSML.Data
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer customer { get; set; }
        public virtual ICollection<InvoiceItem> Items { get; set;}
    }
}
