using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using AutoMapper;
using CarWorkshop.Core.Models;

namespace CarWorkshop.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task AddCar(CarDTO car)
        {
            Car newCar = _mapper.Map<CarDTO, Car>(car);

            await _carRepository.AddCar(newCar);
        }

        public async Task<IEnumerable<CarDTO>> GetAllCars()
        {
            var cars = await _carRepository.GetAllCars();

            IEnumerable<CarDTO> result = _mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(cars);

            return result;
        }

        public async Task<CarDTO> GetCar(int carId)
        {
            Car car = await _carRepository.GetCar(carId);

            CarDTO result = _mapper.Map<Car, CarDTO>(car);

            return result;
        }

        public async Task RemoveCar(int carId)
        {
            await _carRepository.DeleteCar(carId);
        }

        public async Task UpdateCar(CarDTO updatedCar)
        {
            Car carToUpdate = await _carRepository.GetCar(updatedCar.CarId);

            _mapper.Map(updatedCar, carToUpdate);

            await _carRepository.UpdateCar(carToUpdate);
        }
    }
}
