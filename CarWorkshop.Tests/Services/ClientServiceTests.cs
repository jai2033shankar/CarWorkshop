using AutoMapper;
using CarWorkshop.Core.Models;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarWorkshop.Tests.Services
{
    public class ClientServiceTests
    {
        [Fact]
        public async Task GetClient_with_email_should_call_GetClientByEmail_on_repository()
        {
            var ClientRepositoryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();

            var MapperMock = new Mock<IMapper>();
            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object, CarRepositoryMock.Object);

            await ClientService.GetClient(It.IsAny<string>());
            ClientRepositoryMock.Verify(x => x.GetClient(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetClient_with_Id_should_call_GetClientById_on_repository()
        {
            var ClientRepositoryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();
            var MapperMock = new Mock<IMapper>();

            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object, CarRepositoryMock.Object);

            await ClientService.GetClient(It.IsAny<int>());
            ClientRepositoryMock.Verify(x => x.GetClient(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetAllClients_should_call_GetAllClients_on_repository()
        {
            var ClientRepostioryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();
            var MapperMock = new Mock<IMapper>();

            var ClientService = new ClientService(ClientRepostioryMock.Object, MapperMock.Object, CarRepositoryMock.Object);

            await ClientService.GetAllClients();

            ClientRepostioryMock.Verify(x => x.GetAllClients(), Times.Once);
        }

        [Fact]
        public async Task AddClient_should_call_AddClient_on_repository()
        {
            var ClientRepositoryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();
            var MapperMock = new Mock<IMapper>();

            MapperMock.Setup(x => x.Map<ClientDTO, Client>(It.IsAny<ClientDTO>()))
                .Returns(new Client());

            var client = new ClientDTO
            {
                EmailAddress = "xxx@xxx.xyz",
                UserRole = "Client",
                FirstName = "xxx",
                LastName = "yyy",
                IdentityCardNumber = "testNumber",
                Pesel = "testPesel",
                Cars = new List<CarDTO>()
            };

            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object, CarRepositoryMock.Object);

            await ClientService.AddClient(client);

            MapperMock.Verify(x => x.Map<ClientDTO, Client>(It.IsAny<ClientDTO>()), Times.Once);
            ClientRepositoryMock.Verify(x => x.AddClient(It.IsAny<Client>()), Times.Once);

        }

        [Fact]
        public async Task UpdateClient_should_call_GetClientById_and_UpdateClient_on_Repository()
        {
            var ClientRepositoryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();
            var MapperMock = new Mock<IMapper>();

            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object, CarRepositoryMock.Object);

            var client = new ClientDTO
            {
                ClientId = 2,
                EmailAddress = "xxx@xxx.xyz",
                UserRole = "Client",
                FirstName = "xxx",
                LastName = "yyy",
                IdentityCardNumber = "testNumber",
                Pesel = "testPesel",
                Cars = new List<CarDTO>()
            };

            await ClientService.UpdateClient(client);

            ClientRepositoryMock.Verify(x => x.GetClient(It.IsAny<int>()), Times.Once);
            ClientRepositoryMock.Verify(x => x.UpdateClient(It.IsAny<Client>()), Times.Once);
        }

        [Fact]
        public async Task RemoveClient_should_call_RemoveClient_on_repository()
        {
            var ClientRepositoryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();
            var MapperMock = new Mock<IMapper>();

            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object,
                CarRepositoryMock.Object);

            await ClientService.RemoveClient(It.IsAny<int>());

            ClientRepositoryMock.Verify(x => x.RemoveClient(It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public async Task AddCar_should_call_AddCar_on_repository()
        {
            var ClientRepositoryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();
            var MapperMock = new Mock<IMapper>();

            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object, 
                CarRepositoryMock.Object);

            await ClientService.AddCar(It.IsAny<CarDTO>());

            ClientRepositoryMock.Verify(x => x.AddCar(It.IsAny<Car>()), Times.Once);
        }

        [Fact]
        public async Task EditCar_should_call_GetCar_on_CarRepository()
        {
            var ClientRepositoryMock = new Mock<IClientRepository>();
            var CarRepositoryMock = new Mock<ICarRepository>();
            var MapperMock = new Mock<IMapper>();

            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object,
                CarRepositoryMock.Object);


            var carDTOMock = new CarDTO { CarId = 2 };

            await ClientService.EditCar(carDTOMock);

            CarRepositoryMock.Verify(x => x.GetCar(carDTOMock.CarId), Times.Once);
        }
    }
}
