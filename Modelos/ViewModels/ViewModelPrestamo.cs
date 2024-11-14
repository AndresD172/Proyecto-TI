using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class ViewModelPrestamo
    {
        public Prestamo? Prestamo { get; set; }
        public IEnumerable<SelectListItem> Equipos { get; set; }
    }
}
