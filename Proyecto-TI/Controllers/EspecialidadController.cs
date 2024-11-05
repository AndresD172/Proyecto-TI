using Datos;
using Modelos;
using Datos.Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_TI.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly IEspecialidadRepositorio _especialidadRepositorio;

        public EspecialidadController(IEspecialidadRepositorio especialidadRepositorio)
        {
            _especialidadRepositorio = especialidadRepositorio;
        }

        public IActionResult Index()
        {
            //IEnumerable<Especialidad> lista = _especialidadRepositorio.ObtenerTodos;
            //return View(lista);
            return View();
        }

        //GET UPSERT
        public IActionResult Upsert(int? id)
        {
            return View();
        }

        //POST UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                //Nuevo
                if (especialidad.IdEspecialidad == 0)
                {
                    _especialidadRepositorio.Agregar(especialidad);
                }
                //Editar
                else
                {
                    _especialidadRepositorio.Actualizar(especialidad);
                }
                _especialidadRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        //GET ELIMINAR
        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _especialidadRepositorio.Obtener(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST ELIMINAR
        public IActionResult Eliminar(Especialidad especialidad)
        {

            if (especialidad == null)
            {
                return NotFound();
            }

            _especialidadRepositorio.Remover(especialidad);
            _especialidadRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }
    }
}
