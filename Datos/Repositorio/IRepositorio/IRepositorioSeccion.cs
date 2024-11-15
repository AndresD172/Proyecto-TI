using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioSeccion : IRepositorio<Seccion>
    {

        void Actualizar(Seccion seccion);
    }
}
