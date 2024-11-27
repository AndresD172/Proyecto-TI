using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ViewModels;

namespace Proyecto_TI.Controllers
{
    public class SeccionController : Controller
    {
        private readonly IRepositorioSeccion _seccionRepositorio;

        public SeccionController(IRepositorioSeccion seccionRepositorio)
        {
            _seccionRepositorio = seccionRepositorio;
        }

        // GET: Index
        public IActionResult Index()
        {
            IEnumerable<Seccion> lista = _seccionRepositorio.ObtenerTodos();
            ViewModelSeccion SeccionVM = new ViewModelSeccion
            {
                seccion = new Seccion(),
                listaSecciones = lista
            };
            return View(SeccionVM);
        }

        // GET: Upsert
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Crear nueva sección
                return View(new Seccion());
            }
            else
            {
                // Editar sección existente
                var seccion = _seccionRepositorio.Obtener(id.GetValueOrDefault());
                if (seccion == null)
                {
                    return NotFound();
                }
                return View("Editar", seccion);
            }
        }

        // POST: Upsert
        [HttpPost]
        [Route("Seccion/Upsert")]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Seccion seccion)
        {
            var existe = _seccionRepositorio.ObtenerTodos(seguirCambios: false).Any(s => s.NombreSeccion.Equals(seccion.NombreSeccion, StringComparison.OrdinalIgnoreCase) && s.IdSeccion != seccion.IdSeccion);

            if (existe)
            {
               ModelState.AddModelError("seccion.NombreSeccion", "El nombre de la sección ya existe.");
               var viewModel = new ViewModelSeccion
               {
                   seccion = seccion,
                   listaSecciones = _seccionRepositorio.ObtenerTodos().ToList()
               };
                return View("Index", viewModel);
            }
            if (ModelState.IsValid)
            {
                // Nuevo registro
                if (seccion.IdSeccion == 0)
                {
                    _seccionRepositorio.Agregar(seccion);
                }
                // Actualización
                else
                {
                    _seccionRepositorio.Actualizar(seccion);
                }

                _seccionRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }

            return View("Editar", seccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ViewModelSeccion seccion)
        {
            var seccionVar = seccion.seccion;
            Upsert(seccion);
            return RedirectToAction("Index");
        }

        // GET: Eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var seccion = _seccionRepositorio.Obtener(id.GetValueOrDefault());
            if (seccion == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Eliminar
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var seccion = _seccionRepositorio.Obtener(id);
            if (seccion == null)
            {
                return NotFound();
            }

            _seccionRepositorio.Remover(seccion);
            _seccionRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Seccion> lista = _seccionRepositorio.ObtenerTodos(x => x.NombreSeccion.ToLower().Equals(query.ToLower()));
            ViewModelSeccion seccionVM = new ViewModelSeccion
            {
                seccion = new Seccion(),
                listaSecciones = lista
            };
            return View("Index", seccionVM);
        }
    }
}

