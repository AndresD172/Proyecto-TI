using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Collections.Generic;

namespace Proyecto_TI.Controllers
{
    public class InstitucionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public InstitucionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Institucion> lista = _db.Institucion;
            return View(lista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                _db.Institucion.Add(institucion);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(institucion);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Institucion.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                _db.Institucion.Update(institucion);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(institucion);
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Institucion.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Institucion institucion)
        {
            if (institucion == null)
            {
                return NotFound();
            }

            _db.Institucion.Remove(institucion);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
