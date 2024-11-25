using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
	public class ViewModelInstitucion
	{
		public Institucion institucion { get; set; }
		public IEnumerable<Institucion> listaInstituciones { get; set; }
	}
}
