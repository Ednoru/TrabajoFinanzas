using Microsoft.EntityFrameworkCore;
using TrabajoFinanzas.Models;

namespace TrabajoFinanzas.Services.Implementation;

public class ClienteService : IClientService
{
    private readonly DbFinanzasContext _dbFinanzasContext;
    
    public ClienteService(DbFinanzasContext dbFinanzasContext)
    {
        _dbFinanzasContext = dbFinanzasContext;
    }
    
    public async Task<Cliente> GetCliente(string correo, string contrasena)
    {
        Cliente clienteEncontrado = await _dbFinanzasContext.Clientes.Where(c => c.CorreoElectronico == correo && c.Contrasena == contrasena).FirstOrDefaultAsync();

        return clienteEncontrado;
    }
    
    public async Task<Cliente> SaveCliente(Cliente modelo)
    {
        _dbFinanzasContext.Clientes.Add(modelo);
        await _dbFinanzasContext.SaveChangesAsync();
        
        return modelo;
    }
}