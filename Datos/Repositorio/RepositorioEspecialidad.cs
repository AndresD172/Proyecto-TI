using Datos.Repositorio;
using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioEspecialidad : Repositorio<Especialidad>, IRepositorioEspecialidad
    {
        private readonly ApplicationDbContext _db;
        public RepositorioEspecialidad(ApplicationDbContext db) : base(db) //aca necesitamos implementar el db padre 
        {
            _db = db;
        }

        public void Actualizar(Especialidad especialidad)
        {
            var especialidadAnterior = _db.Especialidades.FirstOrDefault(e => e.IdEspecialidad == especialidad.IdEspecialidad);
            if (especialidadAnterior != null)
            {

                especialidadAnterior.NombreEspecialidad = especialidad.NombreEspecialidad;

            }
        }
    }
}
