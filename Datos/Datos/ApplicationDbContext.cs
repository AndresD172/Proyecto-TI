using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {
            
        }

        public DbSet<Prestatario> Prestatario { get; set; }
        public DbSet<TipoPrestatario> TipoPrestatario { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<Institucion> Institucion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CategoriaEquipo> CategoriaEquipo { get; set; }
    }
}
