using Microsoft.EntityFrameworkCore;

using TrabajoFinanzas.Models;
using TrabajoFinanzas.Services;
using TrabajoFinanzas.Services.Implementation;

using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.8
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbFinanzasContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("conexion"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")));

builder.Services.AddScoped<IClientService, ClienteService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion";
        options.LogoutPath = "/Inicio/CerrarSesion";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Para mostrar el index y lo demas
app.MapControllerRoute(
    name: "cliente",      
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Para mostrar el registro e inicio de sesion
//app.MapControllerRoute(
    //name: "cliente",
    //pattern: "{controller=Cliente}/{action=IniciarSesion}/{id?}");

app.Run();
