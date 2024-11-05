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

        public DbSet<Prestatario> Prestatarios { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<CategoriaEquipo> CategoriaEquipo { get; set; }
        public DbSet<Equipo> Equipo {  get; set; }
        public DbSet<Multa> Multa {  get; set; }
        public DbSet<PerfilTecnico> PerfilTecnico { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Reporte> Reporte { get; set; }

    }
}
