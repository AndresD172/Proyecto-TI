using Microsoft.AspNetCore.Mvc;
using Datos.Repositorio.IRepositorio;
using Modelos;

namespace Proyecto_TI.Controllers
{
    public class EquipoController : Controller
    {

        private readonly IRepositorioEquipo _equipoRepositorio;

        public EquipoController(IRepositorioEquipo equipoRepositorio)
        {
            _equipoRepositorio = equipoRepositorio;
        }

        public IActionResult Index()
        {

            IEnumerable<Equipo> lista = _equipoRepositorio.ObtenerTodos();
            
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
        public IActionResult Upsert(Equipo equipo)
        {

            if (ModelState.IsValid)
            {

             //Nuevo
                if (equipo.Id == 0)
                {

                    _equipoRepositorio.Agregar(equipo);

                }
                //Editar
                else
                {

                    _equipoRepositorio.Actualizar(equipo);

                }
                _equipoRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));

            }
            return View(equipo);
        }

         //Get Eliminar
        public IActionResult Eliminar(int? id)
        {

             if (id == null || id == 0)
             {
                return NotFound();
             }

            var obj = _equipoRepositorio.Obtener(id.GetValueOrDefault());

            if(obj == null)
            {
                return NotFound();

            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post Eliminar
        public IActionResult Eliminar(Equipo equipo)
        {

            if (equipo == null)
            { 
                
                return NotFound();

            }
            _equipoRepositorio.Remover(equipo);
            _equipoRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));

        }

    }
}
