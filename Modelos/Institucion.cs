using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Institucion
    {
        [Key]
        public int IdInstitucion { get; set; }

        [Required]
        public string NombreInstitucion { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
