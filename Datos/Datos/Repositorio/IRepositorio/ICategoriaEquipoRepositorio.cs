using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Datos.Repositorio.IRepositorio
{
    public interface ICategoriaEquipoRepositorio : IRepositorio<CategoriaEquipo>
    {
        void Actualizar(CategoriaEquipo categoriaEquipo);
    }
    
}
