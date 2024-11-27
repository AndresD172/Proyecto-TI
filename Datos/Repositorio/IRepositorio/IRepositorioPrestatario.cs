using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioPrestatario : IRepositorio<Prestatario>
    {
        void Actualizar(Prestatario prestatario);

        IEnumerable<SelectListItem> ObtenerOpcionesSecciones();

        IEnumerable<SelectListItem> ObtenerOpcionesEspecialidades();
    }
}
