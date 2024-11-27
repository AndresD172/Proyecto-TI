using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario : IdentityUser
    {
        [PersonalData]
        public string? Nombre { get; set; }

        [PersonalData]
        public string? Apellido { get; set; }
    }
}
