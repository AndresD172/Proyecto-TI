using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ViewModels;

namespace Proyecto_TI.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;
        private readonly IRepositorioEquipo _repositorioEquipo;
        private readonly UserManager<IdentityUser> _userManager;

        public PrestamoController(IRepositorioPrestamo repositorioPrestamo, IRepositorioEquipo repositorioEquipo, UserManager<IdentityUser> userManager)
        {
            _repositorioPrestamo = repositorioPrestamo;
            _repositorioEquipo = repositorioEquipo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Prestamo> prestamos = _repositorioPrestamo.ObtenerTodos(propiedadesAIncluir: ["Equipos", "Prestatario", "Tecnico"]);
            
            return View(prestamos);
        }

        public IActionResult Registrar()
        {
            ViewModelPrestamo viewModelPrestamo = new ViewModelPrestamo
            {
                Prestamo = new Prestamo(),
                Equipos = _repositorioPrestamo.ObtenerOpcionesEquipos(),
                Prestatarios = _repositorioPrestamo.ObtenerOpcionesPrestatarios()
            };

            return View(viewModelPrestamo);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registrar(ViewModelPrestamo viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewModelPrestamo viewModelPrestamo = new ViewModelPrestamo
                {
                    Prestamo = viewModel.Prestamo,
                    Equipos = _repositorioPrestamo.ObtenerOpcionesEquipos(),
                    Prestatarios = _repositorioPrestamo.ObtenerOpcionesPrestatarios()
                };

                return View(viewModelPrestamo);
            }

            // Obtiene la lista de equipos y cambia el estado de los equipos a prestar.
            IEnumerable<Equipo> equipos = _repositorioEquipo.ObtenerTodos().Where(x => viewModel.Prestamo.Equipos.Contains(x));

            foreach (Equipo equipo in equipos)
            {
                equipo.EstadoEquipo = "En préstamo";
            }

            _repositorioEquipo.GuardarCambios();

            // Obtiene el usuario actual basado en sus claims.
            IdentityUser? user = await _userManager.GetUserAsync(User);
            viewModel.Prestamo.IdTecnico = user.Id;

            // Guarda el préstamo.
            _repositorioPrestamo.Agregar(viewModel.Prestamo);

            _repositorioPrestamo.GuardarCambios();

            return View("Index");
        }

        public IActionResult Actualizar(int? id)
        {
            Prestamo prestamo = _repositorioPrestamo.Obtener(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            ViewModelPrestamo viewModelPrestamo = new ViewModelPrestamo
            {
                Prestamo = prestamo,
                Equipos = _repositorioPrestamo.ObtenerOpcionesEquipos(),
                Prestatarios = _repositorioPrestamo.ObtenerOpcionesPrestatarios()
            };

            return View(viewModelPrestamo);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Actualizar(ViewModelPrestamo viewModel)
        {
            _repositorioPrestamo.Actualizar(viewModel.Prestamo);
            _repositorioPrestamo.GuardarCambios();

            return View("Index");
        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Prestamo> prestamos = _repositorioPrestamo.ObtenerTodos(x => x.Prestatario.Identificacion.ToLower().Equals(query.ToLower()));
            return View("Index", prestamos);
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Prestamo? prestamo = _repositorioPrestamo.Obtener(id);

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

            _repositorioPrestamo.Remover(prestamo);
            _repositorioPrestamo.GuardarCambios();

            return RedirectToAction("Index");
        }
    }
}