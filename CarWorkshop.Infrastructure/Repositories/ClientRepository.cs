using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarWorkshop.Core.Models;
using CarWorkshop.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CarWorkshopContext _context;
        private readonly DbSet<Client> clients;
        private readonly DbSet<Car> cars;

        public ClientRepository(CarWorkshopContext context)
        {
            _context = context;
            clients = _context.Set<Client>();

            cars = _context.Set<Car>();
        }

        public void AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("Client object not recived.");
            }

            clients.Add(client);
            _context.SaveChanges();
        }

        public  IEnumerable<Client> GetAllClients()
        {
            
            return clients.Include(x => x.Car).AsEnumerable();
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            var client = await clients.Include(x => x.Car).SingleAsync(c => c.EmailAddress.Contains(email));

            if (client == null)
            {
                throw new Exception($"Client with email address: {email}, could not be found.");
            }

            return client;
        }

        public async Task RemoveClient(int clientId)
        {
            Client clientToDelete = await clients.SingleAsync(c => c.ClientId == clientId);

            if (clientToDelete == null)
            {
                throw new Exception($"Client with id: {clientId}, could not be found.");
            }

            _context.Remove(clientToDelete);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();
        }

        public async Task<Client> GetClientById(int Id)
        {
            var client = await clients.SingleAsync(c => c.ClientId == Id);

            if (client == null)
            {
                throw new Exception($"Client with id: {Id}, could not be found.");
            }

            return client;
        }
    }
}
