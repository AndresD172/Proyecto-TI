using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioSeccion : Repositorio<Seccion>, IRepositorioSeccion
    {
        private readonly ApplicationDbContext _context;

        public RepositorioSeccion(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Seccion seccion)
        {
            _context.Update(seccion);
        }
    }
}