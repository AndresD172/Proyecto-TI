using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Datos.Repositorio
{
    public class RepositorioEquipo : Repositorio<Equipo>, IRepositorioEquipo
    {
        private readonly ApplicationDbContext _db;

        public RepositorioEquipo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Equipo equipo)
        {
            _db.Update(equipo);
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesCategorias()
        {
            return _db.CategoriaEquipos.Select(x => new SelectListItem
            {
                Text = x.DescripcionEquipo,
                Value = x.Id.ToString(),
            });
        } 
    }
}
