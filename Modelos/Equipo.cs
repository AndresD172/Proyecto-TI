using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Equipo
    {

        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string NumeroSerie { get; set; }

        public string Descripcion {  get; set; }

        [Required]
        public string EstadoEquipo { get; set; }

        [ForeignKey("IdCategoriaEquipo")]

        public int IdCategoriaEquipo { get; set; }

        //public virtual CategoriaEquipo? CategoriaEquipo { get; set; }

        public bool Estado { get; set; }

    }
}
