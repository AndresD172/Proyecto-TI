﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EquipoPrestamo", b =>
                {
                    b.Property<int>("EquiposId")
                        .HasColumnType("int");

                    b.Property<int>("PrestamosId")
                        .HasColumnType("int");

                    b.HasKey("EquiposId", "PrestamosId");

                    b.HasIndex("PrestamosId");

                    b.ToTable("EquipoPrestamo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Modelos.CategoriaEquipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescripcionEquipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CategoriaEquipos");
                });

            modelBuilder.Entity("Modelos.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDepartamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Modelos.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("EstadoEquipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoriaEquipo")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoriaEquipo");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("Modelos.Especialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEspecialidad"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreEspecialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEspecialidad");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Modelos.Institucion", b =>
                {
                    b.Property<int>("IdInstitucion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInstitucion"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreInstitucion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInstitucion");

                    b.ToTable("Instituciones");
                });

            modelBuilder.Entity("Modelos.Multa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("EstadoMulta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("int");

                    b.Property<int?>("PrestamoId")
                        .HasColumnType("int");

                    b.Property<double>("Sancion")
                        .HasColumnType("float");

                    b.Property<bool>("TipoMulta")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PrestamoId");

                    b.ToTable("Multas");
                });

            modelBuilder.Entity("Modelos.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("EstadoPrestamo")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaDevolucion")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaPrestamo")
                        .HasColumnType("date");

                    b.Property<int>("IdPrestatario")
                        .HasColumnType("int");

                    b.Property<string>("IdTecnico")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdPrestatario");

                    b.HasIndex("IdTecnico");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Modelos.Prestatario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("IdEspecialidad")
                        .HasColumnType("int");

                    b.Property<int>("IdSeccion")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPrestatario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecialidad");

                    b.HasIndex("IdSeccion");

                    b.ToTable("Prestatarios");
                });

            modelBuilder.Entity("Modelos.Reporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("FechaCreacion")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Reportes");
                });

            modelBuilder.Entity("Modelos.Seccion", b =>
                {
                    b.Property<int>("IdSeccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSeccion"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreSeccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSeccion");

                    b.ToTable("Secciones");
                });

            modelBuilder.Entity("Modelos.TipoPrestatario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartamentoIdDepartamento")
                        .HasColumnType("int");

                    b.Property<int?>("EspecialidadIdEspecialidad")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("IdEDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("IdEspecialidad")
                        .HasColumnType("int");

                    b.Property<int>("IdInstitucion")
                        .HasColumnType("int");

                    b.Property<int>("IdPrestatario")
                        .HasColumnType("int");

                    b.Property<int>("IdSeccion")
                        .HasColumnType("int");

                    b.Property<int?>("InstitucionIdInstitucion")
                        .HasColumnType("int");

                    b.Property<int?>("PrestatarioId")
                        .HasColumnType("int");

                    b.Property<int?>("SeccionIdSeccion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoIdDepartamento");

                    b.HasIndex("EspecialidadIdEspecialidad");

                    b.HasIndex("InstitucionIdInstitucion");

                    b.HasIndex("PrestatarioId");

                    b.HasIndex("SeccionIdSeccion");

                    b.ToTable("TipoPrestatarios");
                });

            modelBuilder.Entity("Modelos.Usuario", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("EquipoPrestamo", b =>
                {
                    b.HasOne("Modelos.Equipo", null)
                        .WithMany()
                        .HasForeignKey("EquiposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Prestamo", null)
                        .WithMany()
                        .HasForeignKey("PrestamosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Modelos.Equipo", b =>
                {
                    b.HasOne("Modelos.CategoriaEquipo", "CategoriaEquipo")
                        .WithMany()
                        .HasForeignKey("IdCategoriaEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaEquipo");
                });

            modelBuilder.Entity("Modelos.Multa", b =>
                {
                    b.HasOne("Modelos.Prestamo", "Prestamo")
                        .WithMany()
                        .HasForeignKey("PrestamoId");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("Modelos.Prestamo", b =>
                {
                    b.HasOne("Modelos.Prestatario", "Prestatario")
                        .WithMany()
                        .HasForeignKey("IdPrestatario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Usuario", "Tecnico")
                        .WithMany()
                        .HasForeignKey("IdTecnico");

                    b.Navigation("Prestatario");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("Modelos.Prestatario", b =>
                {
                    b.HasOne("Modelos.Especialidad", "Especialidad")
                        .WithMany()
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Seccion", "Seccion")
                        .WithMany()
                        .HasForeignKey("IdSeccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Seccion");
                });

            modelBuilder.Entity("Modelos.TipoPrestatario", b =>
                {
                    b.HasOne("Modelos.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoIdDepartamento");

                    b.HasOne("Modelos.Especialidad", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadIdEspecialidad");

                    b.HasOne("Modelos.Institucion", "Institucion")
                        .WithMany()
                        .HasForeignKey("InstitucionIdInstitucion");

                    b.HasOne("Modelos.Prestatario", "Prestatario")
                        .WithMany()
                        .HasForeignKey("PrestatarioId");

                    b.HasOne("Modelos.Seccion", "Seccion")
                        .WithMany()
                        .HasForeignKey("SeccionIdSeccion");

                    b.Navigation("Departamento");

                    b.Navigation("Especialidad");

                    b.Navigation("Institucion");

                    b.Navigation("Prestatario");

                    b.Navigation("Seccion");
                });
#pragma warning restore 612, 618
        }
    }
}
