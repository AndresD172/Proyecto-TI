using Datos;
using Datos.Repositorio;
using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SendGrid.Extensions.DependencyInjection;
using Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddDefaultTokenProviders().AddDefaultUI().
    AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSendGrid(options =>
            options.ApiKey = builder.Configuration.GetValue<string>("SendGrid:Key"));

builder.Services.AddScoped<IRepositorioInstitucion, RepositorioInstitucion>();
builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
builder.Services.AddScoped<IRepositorioMulta, RepositorioMulta>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
builder.Services.AddScoped<IRepositorioSeccion, RepositorioSeccion>();
builder.Services.AddScoped<IRepositorioDepartamento, RepositorioDepartamento>();
builder.Services.AddScoped<IRepositorioCategoriaEquipo, RepositorioCategoriaEquipo>();
builder.Services.AddScoped<IRepositorioEspecialidad, RepositorioEspecialidad>();
builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
