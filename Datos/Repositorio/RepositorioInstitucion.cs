using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioInstitucion : Repositorio<Institucion>, IRepositorioInstitucion
    {
        private readonly ApplicationDbContext _context;

        public RepositorioInstitucion(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Institucion institucion)
        {
            _context.Update(institucion);
        }
    }
}
