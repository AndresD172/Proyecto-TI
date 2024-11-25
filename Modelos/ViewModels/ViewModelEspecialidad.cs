using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
	public class ViewModelEspecialidad
	{
		public Especialidad especialidad { get; set; }
		public IEnumerable<Especialidad> listaEspecialidades { get; set; }
	}
}
