using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Prestatario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre{ get; set; }

        [Required]
        public string PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        [Required]
        public string Identificacion { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string TipoPrestatario { get; set; }

        [ForeignKey(nameof(Seccion))]
        public int IdSeccion { get; set; }

        public virtual Seccion? Seccion { get; set; }

        [ForeignKey(nameof(Especialidad))]
        public int IdEspecialidad { get; set; }
    
        public virtual Especialidad? Especialidad { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
