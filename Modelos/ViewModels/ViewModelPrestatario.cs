using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class ViewModelPrestatario
    {
        public Prestatario Prestatario { get; set; }

        public IEnumerable<SelectListItem> OpcionesEspecialidades { get; set; }

        public IEnumerable<SelectListItem> OpcionesSecciones { get; set; }
    }
}
