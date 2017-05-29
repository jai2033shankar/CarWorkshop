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

        public ClientDTO GetAllClients()
        {
            throw new NotImplementedException();
        }

        public async Task<ClientDTO> GetClient(int ID)
        {
            Client client = await _clientRepository.GetClientById(ID);

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
