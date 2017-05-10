using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;

namespace CarWorkshop.Infrastructure.Services
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository  _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ClientDTO GetClient(int ID)
        {
            Client client = _clientRepository.GetClientById(ID);

            return new ClientDTO
            {
                EmailAddress = client.EmailAddress,
                FirstName = client.FirstName,
                IdentityCardNumber = client.IdentityCardNumber,
                LastName = client.LastName,
                Pesel = client.Pesel,
                PhoneNumber = client.PhoneNumber
            };
        }
    }
}
