using System.ComponentModel.DataAnnotations;

namespace Shoping.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]//tamaño del string "name"
        [Required(ErrorMessage = "El campo {0} es obligario.")] // esto significa que requiere el nombre para el pais
        public string Name { get; set; }
        public int CountryId { get; set; }
       
    }
}
