using Microsoft.AspNetCore.Mvc;
using Datos.Repositorio.IRepositorio;
using Modelos;
using Modelos.ViewModels;


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
            ViewModelEquipo EquipoVM = new ViewModelEquipo
            {
                equipo = new Equipo(),
                listaEquipos = lista
            };

            return View(EquipoVM);


        }

        //Get Upsert
        public IActionResult Upsert(int? id)
        {
            //Nuevo
            if (id == 0)
            {

                return View(new Equipo());

            }
            //Editar
            else
            {
                var equipo = _equipoRepositorio.Obtener(id.GetValueOrDefault());
                if (equipo == null)
                {
                    return NotFound();
                }
                return View("Editar", equipo);
            }


        }

        //Post Upsert
        [HttpPost]
        [Route("Equipo/Upsert")]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Equipo equipo)
        {

            var existe = _equipoRepositorio.ObtenerTodos().Any(e => e.Id.ToString().Equals(equipo.Id.ToString(), StringComparison.OrdinalIgnoreCase) && e.NumeroSerie != equipo.NumeroSerie);


            if (existe)
            {
                ModelState.AddModelError("equipo.Id", "El equipo ya existe.");
                var viewModel = new ViewModelEquipo
                {
                    equipo = equipo,
                    listaEquipos = _equipoRepositorio.ObtenerTodos().ToList()
                };
                return View("Index", viewModel);
            }

            return View("Editar", equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ViewModelEquipo equipo)
        {
            var equipoVar = equipo.equipo;
            Upsert(equipo);
            return RedirectToAction("Index");
        }

        //Get Eliminar
        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _equipoRepositorio.Obtener(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);

        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        //Post Eliminar
        public IActionResult EliminarConfirmado(int id)
        {
            var equipo = _equipoRepositorio.Obtener(id);
            if (equipo == null)
            {

                return NotFound();

            }
            _equipoRepositorio.Remover(equipo);
            _equipoRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Buscar(string query)
        {
            IEnumerable<Equipo> lista = _equipoRepositorio.ObtenerTodos(x => x.Marca.ToLower().Equals(query.ToLower()));
            ViewModelEquipo equipoVM = new ViewModelEquipo
            {
                equipo = new Equipo(),
                listaEquipos = lista
            };
            return View("Index", equipoVM);
        }

    }
}