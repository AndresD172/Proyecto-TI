using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos;

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
            return View(lista);
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
                return View(seccion);
            }
        }

        // POST: Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Seccion seccion)
        {
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

            return View(seccion);
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

            return View(seccion);
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
    }
}

