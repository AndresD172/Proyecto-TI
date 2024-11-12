using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Modelos;

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

        public IActionResult Agregar()
        {
            return View();
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Agregar(Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return View(prestamo);
            }

            // Obtiene el usuario actual basado en sus claims.
            IdentityUser? user = await _userManager.GetUserAsync(User);
            prestamo.IdTecnico = user.Id;

            _repositorio.Agregar(prestamo);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }

        public IActionResult Modificar()
        {
            return View();
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Modificar(Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return View(prestamo);
            }

            _repositorio.Actualizar(prestamo);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }
    }
}
