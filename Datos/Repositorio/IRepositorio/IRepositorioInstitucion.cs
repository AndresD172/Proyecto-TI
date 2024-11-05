using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioInstitucion : IRepositorio<Institucion>
    {
        void Actualizar(Institucion institucion);
    }
}
