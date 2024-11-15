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
    public class RepositorioTipoPrestatario : Repositorio<TipoPrestatario>, IRepositorioTipoPrestatario
    {
        private readonly ApplicationDbContext _context;

        public RepositorioTipoPrestatario(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(TipoPrestatario tipoPrestatario)
        {
            _context.Update(tipoPrestatario);
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesDepartamentos()
        {
            return _context.Departamentos.Select(d => new SelectListItem
            {
                Text = d.NombreDepartamento,
                Value = d.IdDepartamento.ToString()
            });
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesEspecialidades()
        {
            return _context.Especialidades.Select(e => new SelectListItem
            {
                Text = e.NombreEspecialidad,
                Value = e.IdEspecialidad.ToString()
            });
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesInstituciones()
        {
            return _context.Instituciones.Select(i => new SelectListItem
            {
                Text = i.NombreInstitucion,
                Value = i.IdInstitucion.ToString()
            });
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesPrestatarios()
        {
            return _context.Prestatarios.Select(p => new SelectListItem
            {
                Text = p.Nombre + " " + p.PrimerApellido + " " + p.SegundoApellido,
                Value = p.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesSecciones()
        {
            return _context.Secciones.Select(s => new SelectListItem
            {
                Text = s.NombreSeccion,
                Value = s.IdSeccion.ToString()
            });
        }
    }
}
