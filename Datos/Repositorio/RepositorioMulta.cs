using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        private readonly ApplicationDbContext _context;

        public RepositorioMulta(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Multa multa)
        {

            _context.Update(multa);

        }

        public IEnumerable<SelectListItem> ObtenerOpcionesPrestamos()
        {
            return _context.Prestamos
                .Include(p => p.Prestatario) 
                .Select(x => new SelectListItem
                {
                    Text = $"{x.Prestatario.Nombre} {x.Prestatario.PrimerApellido} {x.Prestatario.SegundoApellido}", 
                    Value = x.Id.ToString() 
                })
                .ToList();
        }

    }
}
