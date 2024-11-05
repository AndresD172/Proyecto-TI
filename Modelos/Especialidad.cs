using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Especialidad
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string descripcionEspecialidad { get; set; }

        [Required]
        public bool estado { get; set; }

    }
}
