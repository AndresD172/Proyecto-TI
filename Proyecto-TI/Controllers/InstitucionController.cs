using Datos;
using Modelos;
using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos.ViewModels;
using static System.Collections.Specialized.BitVector32;

namespace Proyecto_TI.Controllers
{
    public class InstitucionController : Controller
    {
        private readonly IRepositorioInstitucion _institucionRepositorio;

        public InstitucionController(IRepositorioInstitucion institucionRepositorio)
        {
            _institucionRepositorio = institucionRepositorio;
        }

        // GET: Index
        public IActionResult Index()
        {
            IEnumerable<Institucion> lista = _institucionRepositorio.ObtenerTodos();
            ViewModelInstitucion InstitucionVM = new ViewModelInstitucion
            {
                institucion = new Institucion(),
                listaInstituciones = lista
            };
            return View(InstitucionVM);
        }

        // GET: Upsert
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Crear nueva institución
                return View(new Institucion());
            }
            else
            {
                // Editar institución existente
                var institucion = _institucionRepositorio.Obtener(id.GetValueOrDefault());
                if (institucion == null)
                {
                    return NotFound();
                }
                return View("Editar", institucion);
            }
        }

        // POST: Upsert
        [HttpPost]
        [Route("Institucion/Upsert")]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Institucion institucion)
        {

            var existe = _institucionRepositorio.ObtenerTodos().Any(i => i.NombreInstitucion.Equals(institucion.NombreInstitucion, StringComparison.OrdinalIgnoreCase) && i.IdInstitucion != institucion.IdInstitucion);

            if (existe)
            {
                ModelState.AddModelError("institucion.NombreInstitucion", "El nombre de la institución ya existe.");
                var viewModel = new ViewModelInstitucion
                {
                    institucion = institucion,
                    listaInstituciones = _institucionRepositorio.ObtenerTodos().ToList()
                };
                return View("Index", viewModel);
            }

            if (ModelState.IsValid)
            {
                // Nuevo registro
                if (institucion.IdInstitucion == 0)
                {
                    _institucionRepositorio.Agregar(institucion);
                }
                // Actualización
                else
                {
                    _institucionRepositorio.Actualizar(institucion);
                }

                _institucionRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }

            return View("Editar", institucion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ViewModelInstitucion institucion)
        {
            var institucionVar = institucion.institucion;
            Upsert(institucion);
            return RedirectToAction("Index");
        }

        // GET: Eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var institucion = _institucionRepositorio.Obtener(id.GetValueOrDefault());
            if (institucion == null)
            {
                return NotFound();
            }

            return View(institucion);
        }

        // POST: Eliminar
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var institucion = _institucionRepositorio.Obtener(id);
            if (institucion == null)
            {
                return NotFound();
            }

            _institucionRepositorio.Remover(institucion);
            _institucionRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Institucion> lista = _institucionRepositorio.ObtenerTodos(x => x.NombreInstitucion.ToLower().Equals(query.ToLower()));
            ViewModelInstitucion institucionVM = new ViewModelInstitucion
            {
                institucion = new Institucion(),
                listaInstituciones = lista
            };
            return View("Index", institucionVM);
        }
    }
}
