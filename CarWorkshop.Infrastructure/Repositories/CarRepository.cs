using CarWorkshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
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

            var test = _context.Car.Include(car => car.Brand)
                                   .Include(x => x.Model)
                                   .Include(x => x.Client);
            
        }

        public Task AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllCarsForClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCar(int carId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
