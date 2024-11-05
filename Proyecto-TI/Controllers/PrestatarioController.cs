using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Collections.Generic;

namespace Proyecto_TI.Controllers
{
    public class PrestatarioController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PrestatarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Prestatario> lista = _db.Prestatario;
            return View(lista); // Ahora estamos pasando la lista de Prestatarios a la vista
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Prestatario prestatario)
        {
            if (ModelState.IsValid)
            {
                _db.Prestatario.Add(prestatario);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(prestatario);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Prestatario.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Prestatario prestatario)
        {
            if (ModelState.IsValid)
            {
                _db.Prestatario.Update(prestatario);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(prestatario);
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Prestatario.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Prestatario prestatario)
        {
            if (prestatario == null)
            {
                return NotFound();
            }

            _db.Prestatario.Remove(prestatario);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
