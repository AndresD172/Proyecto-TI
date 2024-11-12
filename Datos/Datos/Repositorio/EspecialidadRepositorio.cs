using Datos.Datos.Repositorio.IRepositorio;
using Datos.Datos.Repositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Datos
{
    //public class EspecialidadRepositorio : Repositorio<Especialidad>, IEspecialidadRepositorio
    //{
    //    private readonly ApplicationDbContext _db;

    //    public EspecialidadRepositorio(ApplicationDbContext db) : base(db)
    //    {
    //        _db = db;
    //    }

    //    public void Actualizar(Especialidad especialidad)
    //    {
    //        var especialidadAnterior = _db.Especialidad.FirstOrDefault(c => c.IdEspecialidad == especialidad.IdEspecialidad);
    //        if (especialidadAnterior != null)
    //        {
    //            especialidadAnterior.NombreEspecialidad = especialidad.NombreEspecialidad;

    //        }
    //    }

    //}
}
