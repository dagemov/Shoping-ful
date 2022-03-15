using System.ComponentModel.DataAnnotations;

namespace Shoping.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligario.")] 
        public string Name { get; set; }
        public int StateId { get; set; }
    }
}
