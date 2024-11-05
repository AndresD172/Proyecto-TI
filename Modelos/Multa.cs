using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Multa
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string EstadoMulta { get; set; }

        [Required]
        public bool TipoMulta {  get; set; }

        [Required]
        public bool Estado {  get; set; }

        [ForeignKey("IdPrestamo")]
        public int IdPrestamo { get; set; }

        public virtual Prestamo? Prestamo { get; set; }

    }
}
