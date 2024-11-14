using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioMulta : Repositorio<Multa>, IRepositorioMulta
    {

        private readonly ApplicationDbContext _db;

        public RepositorioMulta(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Multa multa)
        {

            _db.Update(multa);

        }

    }
}
