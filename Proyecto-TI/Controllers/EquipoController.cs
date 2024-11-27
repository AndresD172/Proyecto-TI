using Microsoft.AspNetCore.Mvc;
using Datos.Repositorio.IRepositorio;
using Modelos;
using Modelos.ViewModels;
using Microsoft.Identity.Client;

namespace Proyecto_TI.Controllers
{
    public class EquipoController : Controller
    {

        private readonly IRepositorioEquipo _repositorio;

        public EquipoController(IRepositorioEquipo equipoRepositorio)
        {
            _repositorio = equipoRepositorio;
        }

        public IActionResult Index()
        {
            IEnumerable<Equipo> lista = _repositorio.ObtenerTodos(propiedadesAIncluir: ["CategoriaEquipo"]);

            return View(lista);
        }

        public IActionResult Registrar()
        {
            ViewModelEquipo viewModel = new ViewModelEquipo
            {
                Equipo = new Equipo(),
                OpcionesCategoriasEquipo = _repositorio.ObtenerOpcionesCategorias(),
            };

            return View(viewModel);
        }

        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult Registrar(ViewModelEquipo viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewModelEquipo viewModelEquipo = new ViewModelEquipo
                {
                    Equipo = viewModel.Equipo,
                    OpcionesCategoriasEquipo = _repositorio.ObtenerOpcionesCategorias()
                };

                return View(viewModelEquipo);
            }

            viewModel.Equipo.EstadoEquipo = "Disponible";

            _repositorio.Agregar(viewModel.Equipo);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }

        public IActionResult Actualizar(int? id)
        {
            Equipo equipo = _repositorio.Obtener(id);

            if (equipo == null)
            {
                return NotFound();
            }

            ViewModelEquipo viewModel = new ViewModelEquipo
            {
                Equipo = equipo,
                OpcionesCategoriasEquipo = _repositorio.ObtenerOpcionesCategorias()
            };

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Actualizar(ViewModelEquipo viewModel)
        {
            if (!ModelState.IsValid) { return View(viewModel); }

            _repositorio.Actualizar(viewModel.Equipo);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Equipo> resultadosObtenidos = _repositorio.ObtenerTodos(x => x.Modelo.Contains(query));
            return View("Index", resultadosObtenidos);
        }

        public IActionResult Eliminar(int? id)
        {
            Equipo equipo = _repositorio.Obtener(id);

            if (equipo == null)
            {
                return NotFound();
            }

            _repositorio.Remover(equipo);
            _repositorio.GuardarCambios();
         
            return RedirectToAction(nameof(Index));
        }

    }
}
