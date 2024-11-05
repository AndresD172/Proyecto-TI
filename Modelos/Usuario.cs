using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nombreUsuario { get; set; }

        [Required]
        public string correo { get; set; }

        [Required]
        public string contrasena { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}
