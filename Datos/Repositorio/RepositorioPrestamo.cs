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
            IEnumerable<Equipo> equipos = _context.Equipos.AsEnumerable();
            
            IEnumerable<Equipo> equiposDisponibles = equipos.Where(x => x.EstadoEquipo.Equals("Disponible"));

            return equiposDisponibles.Select(x => new SelectListItem
            {
                Text = x.Marca + " "+ x.Modelo,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> ObtenerOpcionesPrestatarios()
        {
            return _context.Prestatarios.Select(x => new SelectListItem
            {
                Text = x.Nombre + " " + x.PrimerApellido + " " + x.SegundoApellido,
                Value = x.Id.ToString()
            });
        }
    }
}