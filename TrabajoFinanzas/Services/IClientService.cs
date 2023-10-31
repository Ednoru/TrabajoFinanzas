using TrabajoFinanzas.Models;

namespace TrabajoFinanzas.Services;

public interface IClientService
{
    Task<Cliente?> GetCliente(string correo, string contrasena);
    Task<Cliente?> SaveCliente(Cliente modelo);
}