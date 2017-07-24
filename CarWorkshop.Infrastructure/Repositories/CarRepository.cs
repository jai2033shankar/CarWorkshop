using CarWorkshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarWorkshop.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarWorkshopContext _context;
        private readonly DbSet<Car> cars;
        public CarRepository(CarWorkshopContext context)
        {
            _context = context;
            cars = _context.Set<Car>();            
        }

        public Task AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCar(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            List<Car> allCars = await cars.Include(c => c.Repair).Include(c => c.Client).ToListAsync();

            return allCars;
        }

        public async Task<IEnumerable<Car>> GetAllCarsForClient(int clientId)
        {
            List<Car> clientCars = await cars.Include(c => c.Repair)
                                             .Include(c => c.Repair)
                                             .Where(c => c.ClientId == clientId)
                                             .ToListAsync();

            return clientCars;
        }

        public async Task<Car> GetCar(int carId)
        {
            Car car = await cars.SingleOrDefaultAsync(c => c.CarId == carId);

            return car;
        }

        public async Task UpdateCar(Car car)
        {
            
        }
    }
}
