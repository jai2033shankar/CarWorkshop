using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;
using CarWorkshop.Infrastructure.DTO;

namespace CarWorkshop.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository )
        {
            _clientRepository = clientRepository;
        }

        public void CreateClient(string firstname, string lastname, string email, string password)
        {
            // Only for testing, change later.
            Client client = _clientRepository.Get(email);
            if (client != null)
            {
                throw new Exception($"Email address already taken: {email}");
            }

            client = new Client(firstname, lastname, email, password);
            _clientRepository.Add(client);
        }

        public ClientDTO Get(string email)
        {
            Client client = _clientRepository.Get(email);

            return new ClientDTO
            {
                Email = client.Email,
                FirstName = client.FirstName,
                ID = client.ID,
                IDCardNumber = client.IDCardNumber,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber
            };
        }
    }
}
