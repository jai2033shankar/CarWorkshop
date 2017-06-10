using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository  _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<ClientDTO> GetAllClients()
        {
            List<ClientDTO> clients = new List<ClientDTO>();

            foreach (var client in _clientRepository.GetAllClients())
            {
                clients.Add(new ClientDTO
                {
                    EmailAddress = client.EmailAddress,
                    FirstName = client.FirstName,
                    IdentityCardNumber = client.IdentityCardNumber,
                    LastName = client.LastName,
                    Pesel = client.Pesel,
                    PhoneNumber = client.PhoneNumber,
                    UserRole = client.UserRole,
                    Password = client.Password
                });
            }

            return clients;
        }

        public async Task<ClientDTO> GetClient(int Id)
        {
            Client client = await _clientRepository.GetClientById(Id);

            return new ClientDTO
            {
                EmailAddress = client.EmailAddress,
                FirstName = client.FirstName,
                IdentityCardNumber = client.IdentityCardNumber,
                LastName = client.LastName,
                Pesel = client.Pesel,
                PhoneNumber = client.PhoneNumber,
                UserRole = client.UserRole,
                Password = client.Password
            };
        }

        public async Task<ClientDTO> GetClient(string email)
        {
            Client client = await _clientRepository.GetClientByEmail(email);

            return new ClientDTO
            {
                EmailAddress = client.EmailAddress,
                FirstName = client.FirstName,
                IdentityCardNumber = client.IdentityCardNumber,
                LastName = client.LastName,
                Pesel = client.Pesel,
                PhoneNumber = client.PhoneNumber,
                UserRole = client.UserRole,
                Password = client.Password
            };
        }

        public async Task<Boolean> AddClient(ClientDTO client)
        {

            var Newclient = new Client
            {
                EmailAddress = client.EmailAddress,
                FirstName = client.FirstName,
                LastName = client.LastName,
                IdentityCardNumber = client.IdentityCardNumber,
                Pesel = client.Pesel,
                PhoneNumber = client.PhoneNumber,
                UserRole = "Client",
                Password = client.Password
            };

            _clientRepository.AddClient(Newclient);

            return true;
        }
    }
}
