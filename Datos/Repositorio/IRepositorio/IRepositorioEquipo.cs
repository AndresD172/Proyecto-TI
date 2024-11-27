using System;
using Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioEquipo : IRepositorio<Equipo>
    {
        void Actualizar(Equipo equipo);

        IEnumerable<SelectListItem> ObtenerOpcionesCategorias();
    }
}
