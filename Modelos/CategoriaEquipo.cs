using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class CategoriaEquipo
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string descripcionEquipo { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}
