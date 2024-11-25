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
        public int Id { get; set; }

        [Required]
        public string Nombre{ get; set; }

        [Required]
        public string PrimerApellido { get; set; }

        [Required]
        public string SegundoApellido { get; set; }

        [Required]
        public string Identificacion { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public bool Estado { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {PrimerApellido} {SegundoApellido}";
            }
        }
    }
}
