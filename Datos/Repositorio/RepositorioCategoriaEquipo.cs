using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioCategoriaEquipo : Repositorio<CategoriaEquipo>, IRepositorioCategoriaEquipo
    {
        private readonly ApplicationDbContext _db;

        public RepositorioCategoriaEquipo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(CategoriaEquipo categoriaEquipo)
        {
            var categoriaEquipoAnterior = _db.CategoriaEquipos.FirstOrDefault(c => c.Id == categoriaEquipo.Id);
            if (categoriaEquipoAnterior != null)
            {
                categoriaEquipoAnterior.DescripcionEquipo = categoriaEquipo.DescripcionEquipo;
            }
        }

    }
}
