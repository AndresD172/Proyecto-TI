using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    public class Prestamo
    {
        [Key] public int Id { get; set; }

        [ForeignKey("IdEquipo")]
        public int IdEquipo { get; set; }

        public virtual Equipo? Equipo { get; set; }

        [ForeignKey("IdPerfilTecnico")]
        public int IdPerfilTecnico { get; set; }

        public virtual PerfilTecnico? PerfilTecnico { get; set; }

        [ForeignKey("IdPrestatario")]
        p
    }
}
