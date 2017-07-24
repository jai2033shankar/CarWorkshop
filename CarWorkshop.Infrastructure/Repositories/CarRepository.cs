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

        public async Task AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("AddCar method received null Car object.");
            }

            await cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(int Id)
        {
            Car car = await GetCar(Id);

            if ( car == null )
            {
                throw new Exception($"Car with Id: {Id} could not be found");
            }

            cars.Remove(car);
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            List<Car> allCars = await cars.Include(c => c.Repair).Include(c => c.Client).ToListAsync();

            return allCars;
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

        public async Task UpdateCar(Car car)
        {
            cars.Update(car);

            await _context.SaveChangesAsync();
        }
    }
}
