using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class RecintoViewModel
    {
        [Required(ErrorMessage = "El campo Código es obligatorio.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no debe exceder mas de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        [StringLength(100, ErrorMessage = "La dirección no debe exceder mas de 100 caracteres.")]
        public string Direccion { get; set; }
    }
}
