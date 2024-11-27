using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class ViewModelEquipo
    {
        public Equipo equipo {  get; set; }
        public IEnumerable<Equipo> listaEquipos { get; set; }
    }
}
