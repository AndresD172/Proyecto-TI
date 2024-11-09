using Datos.Datos.Repositorio.IRepositorio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Datos.Repositorio
{
    //public class CategoriaEquipoRepositorio : Repositorio<CategoriaEquipo>, ICategoriaEquipoRepositorio
    //{
    //    private readonly ApplicationDbContext _db;

    //    public CategoriaEquipoRepositorio(ApplicationDbContext db) : base(db)
    //    {
    //        _db = db;
    //    }

    //    public void Actualizar(CategoriaEquipo categoriaEquipo)
    //    {
    //        var categoriaEquipoAnterior = _db.CategoriaEquipo.FirstOrDefault(c => c.id == categoriaEquipo.id);
    //        if (categoriaEquipoAnterior != null)
    //        {
    //            categoriaEquipoAnterior.descripcionEquipo = categoriaEquipo.descripcionEquipo;
    //        }
    //    }

    //}
}
