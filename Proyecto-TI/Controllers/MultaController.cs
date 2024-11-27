using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ViewModels;

namespace Proyecto_TI.Controllers
{
    public class MultaController : Controller
    {
        private readonly IRepositorioMulta _repositorio;
        private readonly UserManager<IdentityUser> _userManager;

        public MultaController(IRepositorioMulta repositorioMulta, UserManager<IdentityUser> userManager)
        {
            _repositorio = repositorioMulta;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Multa> multa = _repositorio.ObtenerTodos(propiedadesAIncluir: ["Prestamo"]);
            return View(multa);
        }

        public IActionResult Upsert(int? id)
        {
            ViewModelMulta viewModelMulta = new ViewModelMulta
            {
                Multa = new Multa(),
                Prestamos = _repositorio.ObtenerOpcionesPrestamos()
            };

            if (id == null)
            {
                return View(viewModelMulta);
            }
            else
            {
                viewModelMulta.Multa = _repositorio.Obtener(id);
                if (viewModelMulta.Multa == null)
                {
                    return NotFound();
                }
            }

            return View(viewModelMulta);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Upsert(ViewModelMulta viewModelMulta)
        {
            if (!ModelState.IsValid)
            {
                viewModelMulta.Prestamos = _repositorio.ObtenerOpcionesPrestamos();
                return View(viewModelMulta);
            }

            int id = viewModelMulta.Multa.Id;
            if (id == 0)
            {
                IdentityUser? user = await _userManager.GetUserAsync(User);

                _repositorio.Agregar(viewModelMulta.Multa);
            }
            else
            {
                _repositorio.Actualizar(viewModelMulta.Multa);
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

            Multa? multa = _repositorio.Obtener(id);

            if (multa == null)
            {
                return NotFound();
            }

            return View(multa);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Eliminar(Multa multa)
        {
            if (multa == null)
            {
                return NotFound();
            }

            _repositorio.Remover(multa);
            _repositorio.GuardarCambios();

            return RedirectToAction("Index");
        }
    }
}
