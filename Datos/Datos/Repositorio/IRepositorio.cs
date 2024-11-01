using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        T Obtener(int id);

        IEnumerable<T> ObtenerTodos();
    }
}
