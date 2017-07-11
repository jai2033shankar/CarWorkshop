using CarWorkshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Core.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetCar(int carId);

        Task<IEnumerable<Car>> GetAllCars();

        Task<IEnumerable<Car>> GetAllCarsForClient(int clientId);

        Task AddCar(Car car);

        Task DeleteCar(int Id);

        Task UpdateCar(Car car);
    }
}
