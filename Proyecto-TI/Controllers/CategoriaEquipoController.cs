using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ViewModels;

namespace Proyecto_TI.Controllers
{
    public class CategoriaEquipoController : Controller
    {
        private readonly IRepositorioCategoriaEquipo _categoriaEquipoRepositorio;

        public CategoriaEquipoController(IRepositorioCategoriaEquipo categoriaEquipoRepositorio)
        {
            _categoriaEquipoRepositorio = categoriaEquipoRepositorio;
        }

        public IActionResult Index()
        {
            IEnumerable<CategoriaEquipo> lista = _categoriaEquipoRepositorio.ObtenerTodos();
            ViewModelCategoriaEquipo categoriaEquipoVM = new ViewModelCategoriaEquipo
            {
                categoriaEquipo = new CategoriaEquipo(),
				listaCategoriasEquipos = lista
            };
            return View(categoriaEquipoVM);
        }

        //GET UPSERT
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new CategoriaEquipo());
            }
            else
            {
                var categoriaEquipo = _categoriaEquipoRepositorio.Obtener(id.GetValueOrDefault());
                if (categoriaEquipo == null)
                {
                    return NotFound();
                }
                return View("Editar", categoriaEquipo);
            }
        }
        //POST UPSERT
        [HttpPost]
        [Route("CategoriaEquipo/Upsert")]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CategoriaEquipo categoriaEquipo)
        {
            var existe = _categoriaEquipoRepositorio.ObtenerTodos(seguirCambios: false).Any(c => c.DescripcionEquipo.Equals(categoriaEquipo.DescripcionEquipo, StringComparison.OrdinalIgnoreCase) && c.Id != categoriaEquipo.Id);

            if (existe)
            {
                ModelState.AddModelError("categoriaEquipo.DescripcionEquipo", "El nombre de la categoria ya existe.");
                var viewModel = new ViewModelCategoriaEquipo
                {
                    categoriaEquipo = categoriaEquipo,
                    listaCategoriasEquipos = _categoriaEquipoRepositorio.ObtenerTodos().ToList()
                };
                return View("Index", viewModel);
            }

            if (ModelState.IsValid)
            {
                //Nuevo
                if (categoriaEquipo.Id == 0)
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
            return View("Editar", categoriaEquipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ViewModelCategoriaEquipo categoriaEquipo)
        {
            var categoria = categoriaEquipo.categoriaEquipo;
            Upsert(categoria);
            return RedirectToAction("Index");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public IActionResult Buscar(string query) {
            IEnumerable<CategoriaEquipo> lista = _categoriaEquipoRepositorio.ObtenerTodos(x => x.DescripcionEquipo.ToLower().Equals(query.ToLower()));
            ViewModelCategoriaEquipo categoriaEquipoVM =new ViewModelCategoriaEquipo { 
                categoriaEquipo=new CategoriaEquipo(),
				listaCategoriasEquipos = lista
            };
            return View("Index", categoriaEquipoVM);
        }

    }
}
