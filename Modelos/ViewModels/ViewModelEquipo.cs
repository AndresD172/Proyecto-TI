using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class ViewModelEquipo
    {
        public Equipo Equipo { get; set; }

        public IEnumerable<SelectListItem>? OpcionesCategoriasEquipo { get; set; }
    }
}
