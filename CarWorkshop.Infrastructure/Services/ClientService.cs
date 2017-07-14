using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace CarWorkshop.Infrastructure.Services
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository  _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<List<ClientDTO>> GetAllClients()
        {
            List<ClientDTO> clients = new List<ClientDTO>();

            foreach (var client in _clientRepository.GetAllClients())
            {
                clients.Add(_mapper.Map<Client, ClientDTO>(client));
            }

            return clients;
        }

        public async Task<ClientDTO> GetClient(int Id)
        {
            Client client = await _clientRepository.GetClientById(Id);

            return _mapper.Map<Client, ClientDTO>(client);
        }

        public async Task<ClientDTO> GetClient(string email)
        {
            Client client = await _clientRepository.GetClientByEmail(email);

            return _mapper.Map<Client, ClientDTO>(client);
        }

        public async Task AddClient(ClientDTO client)
        {
            var Newclient = _mapper.Map<ClientDTO, Client>(client);
            Newclient.UserRole = 3;

            _clientRepository.AddClient(Newclient);
        }

        public async Task UpdateClient(ClientDTO client)
        {
            Client clientToUpdate = await _clientRepository.GetClientById(client.ClientId);

            _mapper.Map(client, clientToUpdate);

             _clientRepository.UpdateClient(clientToUpdate);
        }

        public async Task RemoveClient(int Id)
        {
            // Add error checking.
            await _clientRepository.RemoveClient(Id);
        }

        public async Task AddCar(CarDTO car)
        {
            var NewCar = _mapper.Map<CarDTO, Car>(car);

            await _clientRepository.AddCar(NewCar);
        }
    }
}
