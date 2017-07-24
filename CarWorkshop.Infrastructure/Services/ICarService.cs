using CarWorkshop.Core.Models;
using CarWorkshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public interface ICarService
    {
        Task<CarDTO> GetCar(int carId);

        Task<IEnumerable<CarDTO>> GetAllCars();

        Task AddCar(CarDTO car);

        Task UpdateCar(CarDTO updatedCar);

        Task RemoveCar(int carId);
    }
}
