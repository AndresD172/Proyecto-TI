using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioTipoPrestatario : IRepositorio<TipoPrestatario>
    {
        void Actualizar(TipoPrestatario tipoPrestatario);

        IEnumerable<SelectListItem> ObtenerOpcionesDepartamentos();
        IEnumerable<SelectListItem> ObtenerOpcionesEspecialidades();
        IEnumerable<SelectListItem> ObtenerOpcionesInstituciones();
        IEnumerable<SelectListItem> ObtenerOpcionesPrestatarios();
        IEnumerable<SelectListItem> ObtenerOpcionesSecciones();
    }
}