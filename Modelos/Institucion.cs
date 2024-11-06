using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Institucion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public required string Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
