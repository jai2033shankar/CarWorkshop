using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarWorkshop.Core.Models;
using CarWorkshop.Core.Repositories;
using Microsoft.EntityFrameworkCore;

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
            _context.SaveChanges()
        }

        public IEnumerable<Client> GetAllClients()
        {
            return clients.AsEnumerable();
        }

        public Client GetClientByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Client GetClientById(int Id)
        {
            throw new NotImplementedException();

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
    }
}
