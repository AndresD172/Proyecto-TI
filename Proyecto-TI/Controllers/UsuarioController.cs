using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Modelos;

namespace Proyecto_TI.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly ApplicationDbContext _db;


        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Usuario> lista = _db.Usuario;
            return View();
        }

        //GET UPSERT
        public IActionResult Upsert(int? id) {
            return View();
        }

        //POST UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Usuario usuario)
        {
            if (ModelState.IsValid) {
                //Nuevo
                if (usuario.id == 0)
                {
                    _db.Usuario.Add(usuario);                                      
                }
                //Editar
                else { 
                    _db.Usuario.Update(usuario);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        //GET ELIMINAR
        public IActionResult Eliminar(int? id) {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj= _db.Usuario.Find(id);

            if (obj == null) {
                return NotFound();
            }

            return View(obj);
        }

        //POST ELIMINAR
        public IActionResult Eliminar(Usuario usuario) {

            if (usuario==null) {
                return NotFound();
            }

            _db.Usuario.Remove(usuario);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
