using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
	public class ViewModelSeccion
	{
		public Seccion seccion { get; set; }
		public IEnumerable<Seccion> listaSecciones { get; set; }
	}
}
