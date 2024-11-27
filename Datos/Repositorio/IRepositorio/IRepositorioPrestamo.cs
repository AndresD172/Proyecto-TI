using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioPrestamo : IRepositorio<Prestamo>
    {
        void Actualizar(Prestamo prestamo);

        IEnumerable<SelectListItem> ObtenerOpcionesEquipos();
        
        IEnumerable<SelectListItem> ObtenerOpcionesPrestatarios();
    }
}
