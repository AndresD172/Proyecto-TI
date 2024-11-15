using System;
using System.Collections.Generic;
using System.Linq;
using Modelos;

namespace Datos.Repositorio.IRepositorio
{
    public interface IRepositorioEspecialidad : IRepositorio<Especialidad>
    {
        void Actualizar(Especialidad especialidad);
    }
}
