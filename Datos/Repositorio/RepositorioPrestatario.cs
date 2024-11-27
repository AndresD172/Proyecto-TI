using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioPrestatario : Repositorio<Prestatario>, IRepositorioPrestatario
    {
        private readonly ApplicationDbContext _context;

        public RepositorioPrestatario(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Prestatario prestatario)
        {
            _context.Update(prestatario);
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesSecciones()
        {
            return _context.Secciones.Select(e => new SelectListItem
            {
                Text = e.NombreSeccion,
                Value = e.IdSeccion.ToString(),
            });
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesEspecialidades()
        {
            return _context.Especialidades.Select(e => new SelectListItem
            {
                Text = e.NombreEspecialidad,
                Value = e.IdEspecialidad.ToString(),
            });
        }
    }
}
