using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioPrestamo : Repositorio<Prestamo>, IRepositorioPrestamo
    {
        private readonly ApplicationDbContext _context;

        public RepositorioPrestamo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Prestamo prestamo)
        {
            _context.Update(prestamo);
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesEquipos()
        {
            return _context.Equipos.Select(x => new SelectListItem
            {
                Text = x.Marca + x.Modelo,
                Value = x.Id.ToString()
            });
        }
    }
}