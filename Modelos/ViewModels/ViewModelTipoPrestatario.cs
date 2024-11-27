using Microsoft.AspNetCore.Mvc.Rendering;

namespace Modelos.ViewModels
{
    public class ViewModelTipoPrestatario
    {
        public TipoPrestatario? TipoPrestatario { get; set; }
        public IEnumerable<SelectListItem>? Departamentos { get; set; }
        public IEnumerable<SelectListItem>? Especialidades { get; set; }
        public IEnumerable<SelectListItem>? Instituciones { get; set; }
        public IEnumerable<SelectListItem>? Prestatarios { get; set; }
        public IEnumerable<SelectListItem>? Secciones { get; set; }

    }
}
