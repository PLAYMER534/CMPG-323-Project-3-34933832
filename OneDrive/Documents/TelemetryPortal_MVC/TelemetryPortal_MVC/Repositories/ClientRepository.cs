using System.Collections.Generic;
using System.Linq;
using TelemetryPortal_MVC.Data;
namespace TelemetryPortal_MVC.Models;

public class ClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Method to retrieve all clients
    public IEnumerable<Client> GetClients()
    {
        return _context.Clients.ToList();
    }

    // Method to retrieve a specific client by ID
    public Client GetClientById(int id)
    {
        return _context.Clients.Find(id);
    }

    // Method to add a new client
    public void AddClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    // Method to update an existing client
    public void UpdateClient(Client client)
    {
        _context.Clients.Update(client);
        _context.SaveChanges();
    }

    // Method to delete a client by ID
    public void DeleteClient(int id)
    {
        var client = _context.Clients.Find(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }

    internal async Task<string?>? GetClientById(Guid value)
    {
        throw new NotImplementedException();
    }

    internal void DeleteClient(Guid id)
    {
        throw new NotImplementedException();
    }
}



