using Microsoft.AspNetCore.Mvc;
using Datos.Repositorio.IRepositorio;
using Modelos;

namespace Proyecto_TI.Controllers
{
    public class ReporteController : Controller
    {
        
        private readonly IRepositorioReporte _reporteRepositorio;

        public ReporteController(IRepositorioReporte reporteRepositorio)
        {
            _reporteRepositorio = reporteRepositorio;
        }

        public IActionResult Index()
        {

            IEnumerable<Reporte> lista = _reporteRepositorio.ObtenerTodos();
            
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
        public IActionResult Upsert(Reporte reporte)
        {

            if(ModelState.IsValid)
            {

                //Nuevo
                if(reporte.Id == 0)
                {

                    _reporteRepositorio.Agregar(reporte);

                }
                //Editar
                else
                {
                    
                    _reporteRepositorio.Actualizar(reporte);
                    
                }
                _reporteRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));

            }
            return View(reporte);

        }

        //Get Eliminar
        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _reporteRepositorio.Obtener(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);

        }

        //Post Eliminar
        public IActionResult Eliminar(Reporte reporte)
        {

            if(reporte == null)
            {

                return NotFound();

            }
            _reporteRepositorio.Remover(reporte);
            _reporteRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));

        }

    }
}
