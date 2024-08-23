using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientRepository _clientRepository;

        // Constructor that takes ClientRepository as a dependency
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = (ClientRepository?)clientRepository;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await Task.Run(() => _clientRepository.GetClients().ToList());
            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await Task.Run(() => _clientRepository.GetClientById(id.Value));
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientName,PrimaryContactEmail,DateOnboarded")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = Guid.NewGuid();
                await Task.Run(() => _clientRepository.AddClient(client));
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await Task.Run(() => _clientRepository.GetClientById(id.Value));
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ClientId,ClientName,PrimaryContactEmail,DateOnboarded")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => _clientRepository.UpdateClient(client));
                }
                catch (Exception)
                {
                    if (!_clientRepository.GetClients().Any(e => e.ClientId == client.ClientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await Task.Run(() => _clientRepository.GetClientById(id.Value));
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = await Task.Run(() => _clientRepository.GetClientById(id));
            if (client != null)
            {
                await Task.Run(() => _clientRepository.DeleteClient(id));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

