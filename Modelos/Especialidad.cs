using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombreEspecialidad { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public Boolean Estado { get; set; }
    }
}