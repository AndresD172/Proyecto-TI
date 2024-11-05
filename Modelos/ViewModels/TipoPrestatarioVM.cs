using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class TipoPrestatarioVM
    {
        public TipoPrestatario tipoPrestatario { get; set; }

        public IEnumerable<SelectListItem>? prestatarioLista { get; set; }

        public IEnumerable<SelectListItem>? seccionLista { get; set; }

        public IEnumerable<SelectListItem>? especialidadLista { get; set; }

        public IEnumerable<SelectListItem>? departamentoLista { get; set; }

        public IEnumerable<SelectListItem>? institucionLista { get; set; }
    }
}
