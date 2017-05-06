using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Models;
using CarWorkshop.Core.Repositories;
using System.Linq;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private static ISet<Client> _clients = new HashSet<Client>
        {
            new Client("test", "testsowski", "test@email.com", "pass")
        };

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public Client Get(Guid Id)
            => _clients.Single(cl => cl.ID == Id);

        public Client Get(string email)
            => _clients.Single(cl => cl.Email == email);

        public IEnumerable<Client> GetAll()
            => _clients;

        public void Remove(Guid Id)
        {
            var client = Get(Id);
            _clients.Remove(client);
        }

        public void Update(Client client)
        {
            //TO DO
        }
    }
}
