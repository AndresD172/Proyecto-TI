using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost, IgnoreAntiforgeryToken]
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

            // Establece el estado del equipo a activo.
            viewModel.Prestamo.Estado = true;

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

            return RedirectToAction("Index");
        }

        public IActionResult Actualizar(int? id)
        {
            Prestamo prestamo = _repositorioPrestamo.Obtener(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            ViewModelPrestamo viewModel = new ViewModelPrestamo
            {
                Prestamo = prestamo,
                Equipos = _repositorioPrestamo.ObtenerOpcionesEquipos(),
                Prestatarios = _repositorioPrestamo.ObtenerOpcionesPrestatarios()
            };

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Actualizar(ViewModelPrestamo viewModel)
        {
            if (!ModelState.IsValid) { return View(viewModel); }

            _repositorioPrestamo.Actualizar(viewModel.Prestamo);
            _repositorioPrestamo.GuardarCambios();

            return RedirectToAction("Index");
        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Prestamo> resultadosObtenidos = _repositorioPrestamo.ObtenerTodos(x => x.Prestatario.Identificacion.ToLower().Equals(query.ToLower()));
            return View("Index", resultadosObtenidos);
        }

        public IActionResult Eliminar(int? id)
        {
            Prestamo prestamoAEliminar = _repositorioPrestamo.Obtener(id);

            if (prestamoAEliminar == null)
            {
                return NotFound();
            }

            // Obtiene la lista de equipos y cambia el estado de los equipos prestados.
            IEnumerable<Equipo> equipos = _repositorioEquipo.ObtenerTodos().Where(x => prestamoAEliminar.Equipos.Contains(x));

            foreach (Equipo equipo in equipos)
            {
                equipo.EstadoEquipo = "Disponible";
            }

            _repositorioEquipo.GuardarCambios();

            _repositorioPrestamo.Remover(prestamoAEliminar);
            _repositorioPrestamo.GuardarCambios();

            return RedirectToAction("Index");
        }
    }
}