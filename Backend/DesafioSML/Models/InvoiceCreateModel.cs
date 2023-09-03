using System.ComponentModel.DataAnnotations;

namespace DesafioSML.Models
{
    public class InvoiceCreateModel
    {
        [Required(ErrorMessage = "Fechas es obligatoria.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Cliente es obligatorio.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Productos son obligatorios")]
        [MinLength(1, ErrorMessage = "Es obligatorio al menos 1 producto.")]
        public List<string> Codes { get; set; }
    }
}
