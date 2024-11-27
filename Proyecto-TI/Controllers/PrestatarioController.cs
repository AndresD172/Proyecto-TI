using Datos;
using Modelos;
using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos.ViewModels;

namespace Proyecto_TI.Controllers
{
    public class PrestatarioController : Controller
    {
        private readonly IRepositorioPrestatario _repositorio;

        public PrestatarioController(IRepositorioPrestatario prestatarioRepositorio)
        {
            _repositorio = prestatarioRepositorio;
        }

        public IActionResult Index()
        {
            IEnumerable<Prestatario> lista = _repositorio.ObtenerTodos();
            return View(lista);
        }

        public IActionResult Registrar()
        {
            ViewModelPrestatario viewModel = new ViewModelPrestatario
            {
                Prestatario = new Prestatario(),
                OpcionesSecciones = _repositorio.ObtenerOpcionesSecciones(),
                OpcionesEspecialidades = _repositorio.ObtenerOpcionesEspecialidades(),
            };

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Registrar(ViewModelPrestatario viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _repositorio.Agregar(viewModel.Prestatario);
            _repositorio.GuardarCambios();

            return View("Index");
        }

        public IActionResult Actualizar(int? id)
        {
            Prestatario prestatario = _repositorio.Obtener(id);

            if (prestatario == null)
            {
                return NotFound();
            }

            ViewModelPrestatario viewModel = new ViewModelPrestatario
            {
                Prestatario = prestatario,
                OpcionesSecciones = _repositorio.ObtenerOpcionesSecciones(),
                OpcionesEspecialidades = _repositorio.ObtenerOpcionesEspecialidades()
            };

            return View(viewModel);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Actualizar(ViewModelPrestatario viewModel)
        {
            _repositorio.Actualizar(viewModel.Prestatario);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }

        // GET: Upsert
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Crear nuevo prestatario
                return View(new Prestatario());
            }
            else
            {
                // Editar prestatario existente
                var prestatario = _repositorio.Obtener(id.GetValueOrDefault());
                if (prestatario == null)
                {
                    return NotFound();
                }
                return View(prestatario);
            }
        }

        // GET: Eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var prestatario = _repositorio.Obtener(id.GetValueOrDefault());
            if (prestatario == null)
            {
                return NotFound();
            }

            return View(prestatario);
        }

        // POST: Eliminar
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var prestatario = _repositorio.Obtener(id);
            if (prestatario == null)
            {
                return NotFound();
            }

            _repositorio.Remover(prestatario);
            _repositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }
    }
}