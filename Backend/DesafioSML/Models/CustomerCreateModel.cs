using System.ComponentModel.DataAnnotations;

namespace DesafioSML.Models
{
    public class CustomerCreateModel
    {
        [Required(ErrorMessage = "Nombre es obligatorio.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Apellido es obligatorio.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Direccion es obligatorio.")]
        public string Address { get; set; }
    }
}
