using Microsoft.AspNetCore.Mvc;

using TrabajoFinanzas.Models;
using TrabajoFinanzas.Resources;
using TrabajoFinanzas.Services;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace TrabajoFinanzas.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClientService _clientService;

        public ClienteController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Cliente cliente)
        {
            cliente.Contrasena = Validations.EncryptKey(cliente.Contrasena);

            Cliente clienteCreado = await _clientService.SaveCliente(cliente);

            if (clienteCreado.IdUser != 0)
            {
                return RedirectToAction("IniciarSesion", "Cliente");
            }

            ViewData["Mensaje"] = "Error al crear el usuario";

            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string contrasena)
        {
            Cliente clienteEncontrado = await _clientService.GetCliente(correo, Validations.EncryptKey(contrasena));

            if (clienteEncontrado == null)
            {
                ViewData["Mensaje"] = "Usuario o contraseña incorrectos";
                return View();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, clienteEncontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties porperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), porperties);

            return RedirectToAction("PlanDePagos", "Home");
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
