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

        public DbSet<Usuario>Usuario { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<CategoriaEquipo> CategoriaEquipo { get; set; }
    }
}
