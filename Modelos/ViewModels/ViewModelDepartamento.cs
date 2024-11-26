using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class ViewModelDepartamento
    {
		public Departamento departamento { get; set; }
		public IEnumerable<Departamento> listaDepartamentos { get; set; }
	}
}
