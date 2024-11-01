using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
