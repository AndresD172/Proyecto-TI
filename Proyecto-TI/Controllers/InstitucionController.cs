using Datos;
using Modelos;
using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos.ViewModels;

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
                return View(institucion);
            }
        }

        // POST: Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Institucion institucion)
        {
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

            return View(institucion);
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
