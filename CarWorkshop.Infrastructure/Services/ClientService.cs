﻿using System;
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
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper, ICarRepository carRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<List<ClientDTO>> GetAllClients()
        {
            List<ClientDTO> clients = new List<ClientDTO>();

            foreach (var client in await _clientRepository.GetAllClients())
            {
                clients.Add(_mapper.Map<Client, ClientDTO>(client));
            }

            return clients;
        }

        public async Task<ClientDTO> GetClient(int Id)
        {
            Client client = await _clientRepository.GetClient(Id);

            return _mapper.Map<Client, ClientDTO>(client);
        }

        public async Task<ClientDTO> GetClient(string email)
        {
            Client client = await _clientRepository.GetClient(email);

            return _mapper.Map<Client, ClientDTO>(client);
        }

        public async Task AddClient(ClientDTO client)
        {
            Client Newclient = _mapper.Map<ClientDTO, Client>(client);
            Newclient.UserRole = 3;

            await _clientRepository.AddClient(Newclient);
        }

        public async Task UpdateClient(ClientDTO client)
        {
            Client clientToUpdate = await _clientRepository.GetClient(client.ClientId);

            _mapper.Map(client, clientToUpdate);

             await _clientRepository.UpdateClient(clientToUpdate);
        }

        public async Task RemoveClient(int Id)
        {
            // Add error checking.
            await _clientRepository.RemoveClient(Id);
        }

        public async Task AddCar(CarDTO car)
        {
            Car NewCar = _mapper.Map<CarDTO, Car>(car);

            await _clientRepository.AddCar(NewCar);
        }

        public async Task EditCar(CarDTO updatedCar)
        {
            Car carToUpdate = await _carRepository.GetCar(updatedCar.CarId);

            _mapper.Map(updatedCar, carToUpdate);

            await _carRepository.UpdateCar(carToUpdate);
        }

        public async Task<IEnumerable<RepairDTO>> GetRepairs(int carId)
        {
            Car car = await _carRepository.GetCar(carId);

            List<RepairDTO> repairs = new List<RepairDTO>(); 

            _mapper.Map(car.Repair, repairs);

            return repairs;
        }
    }
}
