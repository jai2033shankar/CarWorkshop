using CarWorkshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Core.Repositories
{
    public interface IClientRepository
    {
        Client Get(Guid Id);

        Client Get(string email);

        IEnumerable<Client> GetAll();

        void Add(Client client);

        void Remove(Guid Id);

        void Update(Client client);
    
    }
}
