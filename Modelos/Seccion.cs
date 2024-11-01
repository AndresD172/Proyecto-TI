using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Seccion
    {
        [Key]
        public int IdSeccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombreSeccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public Boolean Estado { get; set; }
    }
}
