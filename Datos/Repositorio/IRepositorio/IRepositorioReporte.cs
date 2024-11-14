using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioReporte : IRepositorio<Reporte>
    {

        void Actualizar(Reporte reporte);

    }
}
