using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Collections.Generic;

namespace Proyecto_TI.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EspecialidadController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Especialidad> lista = _db.Especialidad;
            return View(lista); 
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _db.Especialidad.Add(especialidad);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Especialidad.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _db.Especialidad.Update(especialidad);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Especialidad.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Especialidad especialidad)
        {
            if (especialidad == null)
            {
                return NotFound();
            }

            _db.Especialidad.Remove(especialidad);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

