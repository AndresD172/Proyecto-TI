using Microsoft.AspNetCore.Mvc.Rendering;

namespace Modelos.ViewModels
{
    internal class PrestatarioVM
    {
        public Prestatario Prestatario { get; set; }

        public IEnumerable<SelectListItem>? DepartamentoLista { get; set; }
        public IEnumerable<SelectListItem>? EspecialidadLista { get; set; }
        public IEnumerable<SelectListItem>? SeccionLista { get; set; }
    }
}
