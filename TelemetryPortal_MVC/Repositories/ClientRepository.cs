using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Models
{
    public class ClientRepository : IClientRepository
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

        // Method to retrieve a specific client by ID (synchronous)
        public Client GetClientById(Guid id)
        {
            return _context.Clients.FirstOrDefault(c => c.ClientId == id);
        }

        // Asynchronous method to retrieve a specific client by ID
        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
        }

        // Method to add a new client
        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        // Asynchronous method to add a new client
        public async Task AddClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        // Method to update an existing client
        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        // Asynchronous method to update an existing client
        public async Task UpdateClientAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        // Method to delete a client by ID
        public void DeleteClient(Guid id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.ClientId == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

        // Asynchronous method to delete a client by ID
        public async Task DeleteClientAsync(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Client>> GetClientsAsync()
        {
            throw new NotImplementedException();
        }
    }
}



