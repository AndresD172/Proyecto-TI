using Datos;
using Modelos;
using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_TI.Controllers
{
    public class PrestatarioController : Controller
    {
        private readonly IRepositorioPrestatario _prestatarioRepositorio;

        public PrestatarioController(IRepositorioPrestatario prestatarioRepositorio)
        {
            _prestatarioRepositorio = prestatarioRepositorio;
        }

        // GET: Index
        public IActionResult Index()
        {
            IEnumerable<Prestatario> lista = _prestatarioRepositorio.ObtenerTodos();
            return View(lista);
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
                var prestatario = _prestatarioRepositorio.Obtener(id.GetValueOrDefault());
                if (prestatario == null)
                {
                    return NotFound();
                }
                return View(prestatario);
            }
        }

        // POST: Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Prestatario prestatario)
        {
            if (ModelState.IsValid)
            {
                // Nuevo registro
                if (prestatario.Id == 0)
                {
                    _prestatarioRepositorio.Agregar(prestatario);
                }
                // Actualización
                else
                {
                    _prestatarioRepositorio.Actualizar(prestatario);
                }

                _prestatarioRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }

            return View(prestatario);
        }

        // GET: Eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var prestatario = _prestatarioRepositorio.Obtener(id.GetValueOrDefault());
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
            var prestatario = _prestatarioRepositorio.Obtener(id);
            if (prestatario == null)
            {
                return NotFound();
            }

            _prestatarioRepositorio.Remover(prestatario);
            _prestatarioRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }
    }
}