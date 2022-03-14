using System.ComponentModel.DataAnnotations;

namespace Shoping.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        // validando que le nombre no sea nulo
        [Display(Name = "Estado/Departamento")]// cambiar nombre de la variable name en la web
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]//tamaño del string "name"
        [Required(ErrorMessage = "El campo {0} es obligario.")] // esto significa que requiere el nombre para el pais
        //El campo {0} se remplace por la variable a la que hacemos referencia , en este caso name
        // pero recuerde que name = pais en su display
        public string Name { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
