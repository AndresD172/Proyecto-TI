using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Tecnico))]
        public string IdTecnico { get; set; }
        public virtual IdentityUser Tecnico { get; set; }

        [ForeignKey(nameof(Prestatario))]
        public int IdPrestatario { get; set; }
        public virtual Prestatario? Prestatario { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

        [Required(ErrorMessage = "Campo obligatorio.")]
        public DateOnly FechaPrestamo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateOnly FechaDevolucion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int EstadoPrestamo { get; set; }

        public bool Estado { get; set; }
    }
}
