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
        private DbSet<Client> clients;

        public ClientRepository(CarWorkshopContext context)
        {
            _context = context;
            clients = _context.Set<Client>();
        }

        public void AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            clients.Add(client);
            _context.SaveChanges();
        }

        public  IEnumerable<Client> GetAllClients()
        {
            return clients.AsEnumerable();
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            return await clients.SingleAsync(c => c.EmailAddress == email);
        }

        public void RemoveClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetClientById(int Id)
        {
            return await clients.SingleAsync(c => c.ClientId == Id);
        }
    }
}
