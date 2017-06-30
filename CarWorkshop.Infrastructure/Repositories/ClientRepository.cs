using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarWorkshop.Core.Models;
using CarWorkshop.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CarWorkshopContext _context;
        private DbSet<Client> clients;
        private List<Car> cars;
        private List<CarBrand> carBrand;
        private List<CarModel> carModel;

        public ClientRepository(CarWorkshopContext context)
        {
            _context = context;
            clients = _context.Set<Client>();
            cars = _context.Set<Car>().ToList();
            carBrand = _context.Set<CarBrand>().ToList();
            carModel = _context.Set<CarModel>().ToList();
        }

        public void AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            clients.Add(client);
            _context.SaveChanges();
        }

        public  IEnumerable<Client> GetAllClients()
        {
            return clients.AsEnumerable();
        }

        private List<Car> GetCars(Client client)
        {
            var clientCars = cars.Where(c => c.ClientId == client.ClientId).ToList();
            foreach (var car in clientCars)
            {
                car.Brand = carBrand.Single(b => b.BrandId == car.BrandId);
                car.Model = carModel.Single(m => m.ModelId == car.ModelId);
            }
            return clientCars;
        
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            var client = await clients.SingleAsync(c => c.EmailAddress.Contains(email));
            client.Car = GetCars(client);
            return client;
        }

        public void RemoveClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();
        }

        public async Task<Client> GetClientById(int Id)
        { 
            return await clients.SingleAsync(c => c.ClientId == Id);
        }
    }
}
