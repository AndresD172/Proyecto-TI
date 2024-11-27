using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CategoriaEquipo> CategoriaEquipos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Prestatario> Prestatarios { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<TipoPrestatario> TipoPrestatarios { get; set; }
    }
}
