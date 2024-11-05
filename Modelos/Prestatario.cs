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
        public int IdPrestatario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombrePrestatario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string PrimerApellidoPrestatario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string SegundoApellidoPrestatario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string IdentificacionPrestatario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string CorreoPrestatario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public Boolean Estado { get; set; }


    }
}
