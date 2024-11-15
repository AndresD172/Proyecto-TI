using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Datos.Repositorio.IRepositorio;

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

            var EquipoAnterior = _db.Equipos.FirstOrDefault(c => c.Id == equipo.Id);
            if (EquipoAnterior != null)
            {
                EquipoAnterior.NumeroSerie = equipo.NumeroSerie;
            }

        }

    }
}
