using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelemetryPortal_MVC.Models;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> GetClientByIdAsync(Guid id);
    Task AddClientAsync(Client client);
    Task UpdateClientAsync(Client client);
    Task DeleteClientAsync(Guid id);
}

