using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio.IRepositorio
{
    public interface IPrestamo : IRepositorio<Prestamo>
    {
        void Actualizar(Prestamo prestamo);
    }
}
