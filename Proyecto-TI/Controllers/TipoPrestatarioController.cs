using Datos;
using Modelos;
using Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_TI.Controllers
{
    public class TipoPrestatarioController : Controller
    {
        private readonly ApplicationDbContext _db;


        public TipoPrestatarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoPrestatario> lista = _db.TipoPrestatario
                .Include(p => p.Prestatario)
                .Include(s => s.Seccion)
                .Include(e => e.Especialidad)
                .Include(d => d.Departamento)
                .Include(i => i.Institucion);
            return View(lista);
        }

        public IActionResult Upsert(int? id)
        {
            TipoPrestatarioVM tipoPrestatarioVM = new TipoPrestatarioVM()
            {
                tipoPrestatario = new TipoPrestatario(),
                prestatarioLista = _db.Prestatario.Select(p => new SelectListItem
                {
                    Text = p.NombrePrestatario,
                    Value = p.IdPrestatario.ToString()
                }),
                seccionLista = _db.Seccion.Select(s => new SelectListItem
                {
                    Text = s.NombreSeccion,
                    Value = s.IdSeccion.ToString()
                }),
                especialidadLista = _db.Especialidad.Select(e => new SelectListItem
                {
                    Text = e.NombreEspecialidad,
                    Value = e.IdEspecialidad.ToString()
                }),
                departamentoLista = _db.Departamento.Select(d => new SelectListItem
                {
                    Text = d.NombreDepartamento,
                    Value = d.IdDepartamento.ToString()
                }),
                institucionLista = _db.Institucion.Select(i => new SelectListItem
                {
                    Text = i.NombreInstitucion,
                    Value = i.IdInstitucion.ToString()
                }),
            };

            if (id == null)
            {
                return View(tipoPrestatarioVM);
            }
            else
            {
                tipoPrestatarioVM.tipoPrestatario = _db.TipoPrestatario.Find(id);

                if (tipoPrestatarioVM == null)
                {
                    return NotFound();
                }

                return View(tipoPrestatarioVM);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(TipoPrestatarioVM tipoPrestatarioVM)
        {
            if (ModelState.IsValid)
            {
                if (tipoPrestatarioVM.tipoPrestatario.IdTipoPrestatario != 0)
                {
                    _db.TipoPrestatario.Add(tipoPrestatarioVM.tipoPrestatario);
                }
                else
                {
                    _db.TipoPrestatario.Update(tipoPrestatarioVM.tipoPrestatario);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPrestatarioVM);
        }

        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            TipoPrestatario tipoPrestatario = _db.TipoPrestatario.FirstOrDefault(t => t.IdTipoPrestatario == id);

            if (tipoPrestatario == null)
            {
                return NotFound();
            }

            return View(tipoPrestatario); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Eliminar(TipoPrestatario tipoPrestatario)
        {
            if (tipoPrestatario == null)
            {
                return NotFound();

            }

            _db.TipoPrestatario.Remove(tipoPrestatario);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
