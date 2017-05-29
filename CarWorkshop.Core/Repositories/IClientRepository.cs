using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Models;
using System.Threading.Tasks;

namespace CarWorkshop.Core.Repositories
{
    public interface IClientRepository
    {
        //Client GetClientById(int Id);

        Task<Client> GetClientById(int Id);

        Client GetClientByEmail(string email);

        IEnumerable<Client> GetAllClients();

        void AddClient(Client client);

        void RemoveClient(int clientId);

        void UpdateClient(Client client);

        void SaveChanges();
    }
}
