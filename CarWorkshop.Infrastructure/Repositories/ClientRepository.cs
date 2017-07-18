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
        private readonly DbSet<Client> clients;
        private readonly DbSet<Car> cars;

        public ClientRepository(CarWorkshopContext context)
        {
            _context = context;
            clients = _context.Set<Client>();

            cars = _context.Set<Car>();
        }

        public async Task AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("Client object not recived.");
            }

            await clients.AddAsync(client);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            IEnumerable<Client> allClients = await clients.Include(x => x.Car).ToListAsync();

            if (allClients == null)
            {
                throw new Exception("Could not load any clients from database");
            }

            return allClients;
        }

        public async Task<Client> GetClient(string email)
        {
            Client client = await clients.Include(x => x.Car)
                            .ThenInclude(car => car.Repair)
                            .SingleOrDefaultAsync(c => c.EmailAddress.Contains(email));

            if (client == null)
            {
                throw new Exception($"Client with email address: {email}, could not be found.");
            }

            return client;
        }

        public async Task<Client> GetClient(int Id)
        {
            Client client = await clients.SingleAsync(c => c.ClientId == Id);

            if (client == null)
            {
                throw new ArgumentNullException($"Client with id: {Id}, could not be found.");
            }

            return client;
        }

        public async Task RemoveClient(int clientId)
        {
            Client clientToDelete = await clients.SingleAsync(c => c.ClientId == clientId);

            if (clientToDelete == null)
            {
                throw new ArgumentNullException($"Client with id: {clientId}, could not be found.");
            }

            clients.Remove(clientToDelete);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("UpdateClient method received null Client object.");
            }

            clients.Update(client);
            _context.SaveChanges();
        }

        public async Task AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("AddCar method received null Car object.");
            }

            await cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task EditCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("EditCar method received null Car object.");
            }

            cars.Update(car);

           await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCar(int carId)
        {
            Car result = await cars.SingleOrDefaultAsync(c => c.CarId == carId);

            if (result == null)
            {
                throw new ArgumentNullException($"Car with id: {carId} was not found in database.");
            }

            return result;
        }
    }
}
