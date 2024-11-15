using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ViewModels;

namespace Proyecto_TI.Controllers
{
    public class TipoPrestatarioController : Controller
    {
        private readonly IRepositorioTipoPrestatario _repositorio;
        private readonly UserManager<IdentityUser> _userManager;

        public TipoPrestatarioController(IRepositorioTipoPrestatario repositorioTipoPrestatario, UserManager<IdentityUser> userManager)
        {
            _repositorio = repositorioTipoPrestatario;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoPrestatario> tipoPrestatarios = _repositorio.ObtenerTodos(propiedadesAIncluir: ["Departamento", "Especialidad", "Institucion", "Prestatario", "Seccion"]);
            return View(tipoPrestatarios);
        }

        public IActionResult Upsert(int? id)
        {
            ViewModelTipoPrestatario viewModelTipoPrestatario = new ViewModelTipoPrestatario
            {
                TipoPrestatario = new TipoPrestatario(),
                Departamentos = _repositorio.ObtenerOpcionesDepartamentos(),
                Especialidades = _repositorio.ObtenerOpcionesEspecialidades(),
                Instituciones = _repositorio.ObtenerOpcionesInstituciones(),
                Prestatarios = _repositorio.ObtenerOpcionesPrestatarios(),
                Secciones = _repositorio.ObtenerOpcionesSecciones()
            };

            if (id == null)
            {
                return View(viewModelTipoPrestatario);
            }
            else
            {
                viewModelTipoPrestatario.TipoPrestatario = _repositorio.Obtener(id);
                if (viewModelTipoPrestatario.TipoPrestatario == null)
                {
                    return NotFound();
                }
            }

            return View(viewModelTipoPrestatario);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Upsert(ViewModelTipoPrestatario viewModelTipoPrestatario)
        {
            if (!ModelState.IsValid)
            {
                viewModelTipoPrestatario.Departamentos = _repositorio.ObtenerOpcionesDepartamentos();
                viewModelTipoPrestatario.Especialidades = _repositorio.ObtenerOpcionesEspecialidades();
                viewModelTipoPrestatario.Instituciones = _repositorio.ObtenerOpcionesInstituciones();
                viewModelTipoPrestatario.Prestatarios = _repositorio.ObtenerOpcionesPrestatarios();
                viewModelTipoPrestatario.Secciones = _repositorio.ObtenerOpcionesSecciones();
                return View(viewModelTipoPrestatario);
            }

            int id = viewModelTipoPrestatario.TipoPrestatario.Id;
            if (id == 0)
            {
                IdentityUser? user = await _userManager.GetUserAsync(User);
                // viewModelTipoPrestatario.TipoPrestatario.Id = user.Id;

                _repositorio.Agregar(viewModelTipoPrestatario.TipoPrestatario);
            }
            else
            {
                _repositorio.Actualizar(viewModelTipoPrestatario.TipoPrestatario);
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

            TipoPrestatario? tipoPrestatario = _repositorio.Obtener(id);

            if (tipoPrestatario == null)
            {
                return NotFound();
            }

            return View(tipoPrestatario);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Eliminar(TipoPrestatario tipoPrestatario)
        {
            if (tipoPrestatario == null)
            {
                return NotFound();
            }

            _repositorio.Remover(tipoPrestatario);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }
    }
}
