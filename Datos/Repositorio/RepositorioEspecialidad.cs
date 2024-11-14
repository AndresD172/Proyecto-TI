using Datos.Repositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Repositorio.IRepositorio;

namespace Datos.Repositorio
{
    public class RepositorioEspecialidad : Repositorio<Especialidad>, IRepositorioEspecialidad
    {
        private readonly ApplicationDbContext _db;

        public RepositorioEspecialidad(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Especialidad especialidad)
        {
            var especialidadAnterior = _db.Especialidades.FirstOrDefault(c => c.IdEspecialidad == especialidad.IdEspecialidad);
            if (especialidadAnterior != null)
            {
                especialidadAnterior.NombreEspecialidad = especialidad.NombreEspecialidad;

            }
        }

    }
}
