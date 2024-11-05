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
        public int Id { get; set; }

        [Required]
        public string DescripcionEquipo { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
