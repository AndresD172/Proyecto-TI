using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioPrestatario : Repositorio<Prestatario>, IRepositorioPrestatario
    {
        private readonly ApplicationDbContext _context;

        public RepositorioPrestatario(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Prestatario prestatario)
        {
            _context.Update(prestatario);
        }
    }
}
