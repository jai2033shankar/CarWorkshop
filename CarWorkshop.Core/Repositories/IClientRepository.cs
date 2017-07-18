using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Models;
using System.Threading.Tasks;

namespace CarWorkshop.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetClient(int Id);

        Task<Client> GetClient(string email);

        Task<IEnumerable<Client>> GetAllClients();

        Task AddClient(Client client);

        Task RemoveClient(int clientId);

        void UpdateClient(Client client);

        Task AddCar(Car car);

        Task EditCar(Car car);

        Task<Car> GetCar(int carId);

    }
}
