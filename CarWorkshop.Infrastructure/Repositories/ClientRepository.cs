﻿using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Models;
using CarWorkshop.Core.Repositories;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private static ISet<Client> _clients = new HashSet<Client>();

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public IEnumerable<Client> GetAllClients()
        {
            throw new NotImplementedException();
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

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
