using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdEquipo")]
        public int IdEquipo { get; set; }

        public virtual Equipo? Equipo { get; set; }

        [ForeignKey("IdTecnico")]
        public int IdTecnico { get; set; }

        [ForeignKey("IdPrestatario")]
        public int IdPrestatario { get; set; }

        public virtual Prestatario? Prestatario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public DateOnly FechaPrestamo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateOnly FechaDevolucion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int EstadoPrestamo { get; set; }

        public bool Estado { get; set; }
    }
}
