using Microsoft.AspNetCore.Mvc;
using Datos.Repositorio.IRepositorio;
using Modelos;

namespace Proyecto_TI.Controllers
{
    public class MultaController : Controller
    {
        private readonly IRepositorioMulta _multaRepositorio;

        public MultaController(IRepositorioMulta multaRepositorio)
        {

            _multaRepositorio = multaRepositorio;

        }



        public IActionResult Index()
        {

            IEnumerable<Multa> lista = _multaRepositorio.ObtenerTodos();

            return View(lista);

        }

        //Get Upsert
        public IActionResult Upsert(int? id)
        {

            return View();

        }

        //Post Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Multa multa)
        {
            if(ModelState.IsValid)
            {

                //Nuevo
                if (multa.Id == 0)
                {

                    _multaRepositorio.Agregar(multa);

                }
                //Editar
                else
                {

                    _multaRepositorio.Actualizar(multa);

                }
                _multaRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));

            }
            return View(multa);
        }

        //Get Eliminar
        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _multaRepositorio.Obtener(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);
        }

        //Post Eliminar
        public IActionResult Eliminar(Multa multa)
        {

            if (multa == null)
            {

                return NotFound();

            }
            _multaRepositorio.Remover(multa);
            _multaRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }

    }
}
