using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ViewModels;

namespace Proyecto_TI.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IRepositorioPrestamo _repositorio;
        private readonly UserManager<IdentityUser> _userManager;

        public PrestamoController(IRepositorioPrestamo repositorioPrestamo, UserManager<IdentityUser> userManager)
        {
            _repositorio = repositorioPrestamo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Prestamo> prestamos = _repositorio.ObtenerTodos(propiedadesAIncluir: ["Equipos", "Prestatario", "Tecnico"]);
            return View(prestamos);
        }

        public IActionResult Upsert(int? id)
        {
            ViewModelPrestamo viewModelPrestamo = new ViewModelPrestamo
            {
                Prestamo = new Prestamo(),
                Equipos = _repositorio.ObtenerOpcionesEquipos()
            };

            if (id == null)
            {
                return View(viewModelPrestamo);
            }
            else
            {
                viewModelPrestamo.Prestamo = _repositorio.Obtener(id);
                if (viewModelPrestamo.Prestamo == null)
                {
                    return NotFound();
                }
            }

            return View(viewModelPrestamo);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Upsert(ViewModelPrestamo viewModelPrestamo)
        {
            if (!ModelState.IsValid)
            {
                // Reinicia la lista de equipos del préstamo.
                viewModelPrestamo.Equipos = _repositorio.ObtenerOpcionesEquipos();
                return View(viewModelPrestamo);
            }

            int id = viewModelPrestamo.Prestamo.Id;
            if (id == 0)
            {
                // Obtiene el usuario actual basado en sus claims.
                IdentityUser? user = await _userManager.GetUserAsync(User);
                viewModelPrestamo.Prestamo.IdTecnico = user.Id;

                _repositorio.Agregar(viewModelPrestamo.Prestamo);
            }
            else
            {
                _repositorio.Actualizar(viewModelPrestamo.Prestamo);
            }

            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Prestamo? prestamo = _repositorio.Obtener(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Eliminar(Prestamo prestamo)
        {
            if (prestamo == null)
            {
                return NotFound();
            }

            _repositorio.Remover(prestamo);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }
    }
}