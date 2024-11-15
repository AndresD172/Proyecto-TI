using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }

        [Required]
        public string NombreDepartamento { get; set; }

        [Required]
        public bool Estado {  get; set; }
    }
}
