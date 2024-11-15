using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class TipoPrestatario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdSeccion")]
        public int IdSeccion { get; set; }

        public virtual Seccion? Seccion { get; set; }

        [ForeignKey("IdEspecialidad")]
        public int IdEspecialidad { get; set; }

        public virtual Especialidad? Especialidad { get; set; }

        [ForeignKey("IdDepartamento")]
        public int IdEDepartamento { get; set; }

        public virtual Departamento? Departamento { get; set; }

        [ForeignKey("IdInstitucion")]
        public int IdInstitucion { get; set; }

        public virtual Institucion? Institucion { get; set; }

        [ForeignKey("IdPrestatario")]
        public int IdPrestatario { get; set; }

        public virtual Prestatario? Prestatario { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
