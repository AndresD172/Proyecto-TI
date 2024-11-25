using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Modelos.ViewModels
{
    public class ViewModelCategoriaEquipo
    {
        public CategoriaEquipo categoriaEquipo { get; set; }
        public IEnumerable<CategoriaEquipo> listaCategoriasEquipos { get; set; }
    }
}
