using Datos.Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace Proyecto_TI.Controllers
{
    public class CategoriaEquipoController : Controller
    {
        private readonly ICategoriaEquipoRepositorio _categoriaEquipoRepositorio;

        public CategoriaEquipoController(ICategoriaEquipoRepositorio categoriaEquipoRepositorio)
        {
            _categoriaEquipoRepositorio = categoriaEquipoRepositorio;
        }

        public IActionResult Index()
        {
            IEnumerable<CategoriaEquipo> lista = _categoriaEquipoRepositorio.ObtenerTodos;
            return View(lista);

        }

        //GET UPSERT
        public IActionResult Upsert(int? id)
        {
            return View();
        }

        //POST UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CategoriaEquipo categoriaEquipo)
        {
            if (ModelState.IsValid)
            {
                //Nuevo
                if (categoriaEquipo.id == 0)
                {
                    _categoriaEquipoRepositorio.Agregar(categoriaEquipo);
                }
                //Editar
                else
                {
                    _categoriaEquipoRepositorio.Actualizar(categoriaEquipo);
                }
                _categoriaEquipoRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaEquipo);
        }

        //GET ELIMINAR
        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _categoriaEquipoRepositorio.Obtener(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST ELIMINAR
        public IActionResult Eliminar(CategoriaEquipo categoriaEquipo)
        {

            if (categoriaEquipo == null)
            {
                return NotFound();
            }

            _categoriaEquipoRepositorio.Remover(categoriaEquipo);
            _categoriaEquipoRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }
    }
}
