using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Seccion
    {
        [Key]
        public int IdSeccion { get; set; }

        [Required]
        public string NombreSeccion { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
