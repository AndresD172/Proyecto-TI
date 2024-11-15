using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioReporte : Repositorio<Reporte>, IRepositorioReporte
    {

        private readonly ApplicationDbContext _db;

        public RepositorioReporte(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Reporte reporte)
        {

            _db.Update(reporte);

        }

    }
}
