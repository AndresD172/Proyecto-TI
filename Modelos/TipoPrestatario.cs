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
        public int IdTipoPrestatario { get; set; }

        public int IdPrestatario { get; set; }
        [ForeignKey("IdPrestatario")]
        public virtual Prestatario? Prestatario { get; set; }

        public int? IdSeccion { get; set; }
        [ForeignKey("IdSeccion")]
        public virtual Seccion? Seccion { get; set; }

        public int? IdEspecialidad { get; set; }
        [ForeignKey("IdEspecialidad")]
        public virtual Especialidad? Especialidad { get; set; }

        public int? IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual Departamento? Departamento { get; set; }

        public int IdInstitucion { get; set; }
        [ForeignKey("IdInstitucion")]
        public virtual Institucion? Institucion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public Boolean Estado { get; set; }
    }
}
