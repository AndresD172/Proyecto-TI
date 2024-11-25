using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class ViewModelMulta
    {
        public Multa? Multa { get; set; }
        public IEnumerable<SelectListItem> Prestamos { get; set; }

    }
}
