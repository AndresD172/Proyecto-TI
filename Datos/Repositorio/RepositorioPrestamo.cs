using Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioPrestamo : Repositorio<Prestamo>, IPrestamo
    {
        private readonly ApplicationDbContext _context;

        public RepositorioPrestamo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Prestamo prestamo) { }
    }
}
