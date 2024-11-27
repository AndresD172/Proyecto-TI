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
            IEnumerable<Prestatario> lista = _repositorio.ObtenerTodos(propiedadesAIncluir: ["Seccion", "Especialidad"]).ToList();
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

            return RedirectToAction("Index");
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
            if (!ModelState.IsValid) { return View(viewModel); }

            _repositorio.Actualizar(viewModel.Prestatario);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Prestatario> resultadosObtenidos = _repositorio.ObtenerTodos(x => x.Identificacion.ToLower().Equals(query.ToLower()), propiedadesAIncluir: ["Seccion", "Especialidad"]);
            return View("Index", resultadosObtenidos);
        }

        public IActionResult Eliminar(int? id)
        {
            Prestatario prestatarioAEliminar = _repositorio.Obtener(id);

            if (prestatarioAEliminar == null)
            {
                return NotFound();
            }

            _repositorio.Remover(prestatarioAEliminar);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }
    }
}