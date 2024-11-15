using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioDepartamento : Repositorio<Departamento>, IRepositorioDepartamento
    {
        private readonly ApplicationDbContext _context;

        public RepositorioDepartamento(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Departamento departamento)
        {
            _context.Update(departamento);
        }
    }
}
