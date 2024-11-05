using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombreDepartamento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public bool Estado {  get; set; }
    }
}
