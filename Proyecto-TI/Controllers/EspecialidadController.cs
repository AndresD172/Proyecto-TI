using Datos;
using Modelos;
using Microsoft.AspNetCore.Mvc;
using Datos.Repositorio.IRepositorio;
using Modelos.ViewModels;
using static System.Collections.Specialized.BitVector32;

namespace Proyecto_TI.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly IRepositorioEspecialidad _especialidadRepositorio;

        public EspecialidadController(IRepositorioEspecialidad especialidadRepositorio)
        {
            _especialidadRepositorio = especialidadRepositorio;
        }

        // GET: Index
        public IActionResult Index()
        {
            IEnumerable<Especialidad> lista = _especialidadRepositorio.ObtenerTodos();
            ViewModelEspecialidad EspecialidadVM = new ViewModelEspecialidad
            {
                especialidad = new Especialidad(),
                listaEspecialidades = lista
            };
            return View(EspecialidadVM);
        }

        // GET: Upsert
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Crear nueva especialidad
                return View(new Especialidad());
            }
            else
            {
                // Editar especialidad existente
                var especialidad = _especialidadRepositorio.Obtener(id.GetValueOrDefault());
                if (especialidad == null)
                {
                    return NotFound();
                }
                return View("Editar", especialidad);
            }
        }

        // POST: Upsert
        [HttpPost]
        [Route("Especialidad/Upsert")]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Especialidad especialidad)
        {
            var existe = _especialidadRepositorio.ObtenerTodos(seguirCambios: false).Any(e => e.NombreEspecialidad.Equals(especialidad.NombreEspecialidad, StringComparison.OrdinalIgnoreCase) && e.IdEspecialidad != especialidad.IdEspecialidad);

            if (existe)
            {
                ModelState.AddModelError("especialidad.NombreEspecialidad", "El nombre de la especialidad ya existe.");
                var viewModel = new ViewModelEspecialidad
                {
                    especialidad = especialidad,
                    listaEspecialidades = _especialidadRepositorio.ObtenerTodos().ToList()
                };
                return View("Index", viewModel);
            }

            if (ModelState.IsValid)
            {
                // Nuevo registro
                if (especialidad.IdEspecialidad == 0)
                {
                    _especialidadRepositorio.Agregar(especialidad);
                }
                // Actualización
                else
                {
                    _especialidadRepositorio.Actualizar(especialidad);
                }

                _especialidadRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }

            return View("Editar", especialidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ViewModelEspecialidad especialidad)
        {
            var especialidadVar = especialidad.especialidad;
            Upsert(especialidad);
            return RedirectToAction("Index");
        }
        // GET: Eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var especialidad = _especialidadRepositorio.Obtener(id.GetValueOrDefault());
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST: Eliminar
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var especialidad = _especialidadRepositorio.Obtener(id);
            if (especialidad == null)
            {
                return NotFound();
            }

            _especialidadRepositorio.Remover(especialidad);
            _especialidadRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Especialidad> lista = _especialidadRepositorio.ObtenerTodos(x => x.NombreEspecialidad.ToLower().Equals(query.ToLower()));
            ViewModelEspecialidad especialidadVM = new ViewModelEspecialidad
            {
                especialidad = new Especialidad(),
                listaEspecialidades = lista
            };
            return View("Index", especialidadVM);
        }
    }
}
