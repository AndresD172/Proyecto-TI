using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Collections.Generic;

namespace Proyecto_TI.Controllers
{
    public class SeccionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SeccionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Seccion> lista = _db.Seccion;
            return View(lista); 
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                _db.Seccion.Add(seccion);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(seccion);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Seccion.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                _db.Seccion.Update(seccion);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(seccion);
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Seccion.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Seccion seccion)
        {
            if (seccion == null)
            {
                return NotFound();
            }

            _db.Seccion.Remove(seccion);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
