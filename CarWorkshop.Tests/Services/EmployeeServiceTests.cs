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
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetAllEmployees_should_call_GetAllEmmplyees_on_repository()
        {
            var EmployeeRepositoryMock = new Mock<IEmployeeRepository>();
            var MapperMock = new Mock<IMapper>();

            var EmployeeService = new EmployeeService(EmployeeRepositoryMock.Object, MapperMock.Object);

            await EmployeeService.GetAllEmployees();

            EmployeeRepositoryMock.Verify(x => x.GetAllEmployees(), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeById_should_call_GetEmployeeById_on_repository()
        {
            var EmployeeRepositoryMock = new Mock<IEmployeeRepository>();
            var MapperMock = new Mock<IMapper>();

            var EmployeeService = new EmployeeService(EmployeeRepositoryMock.Object, MapperMock.Object);

            await EmployeeService.GetEmployee(It.IsAny<int>());

            EmployeeRepositoryMock.Verify(x => x.GetEmployee(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task AddEmployee_should_call_AddEmployee_on_repository()
        {
            // TO DO
        }

        [Fact]
        public async Task GetPositions_should_call_GetPositions_on_repository()
        {
            var EmployeeRepositoryMock = new Mock<IEmployeeRepository>();
            var MapperMock = new Mock<IMapper>();

            var EmployeeService = new EmployeeService(EmployeeRepositoryMock.Object, MapperMock.Object);

            await EmployeeService.GetPositions();

            EmployeeRepositoryMock.Verify(x => x.GetPositions(), Times.Once);
        }

        [Fact]
        public async Task GetToles_should_call_GetRoles_on_repository()
        {
            var EmployeeRepositoryMock = new Mock<IEmployeeRepository>();
            var MapperMock = new Mock<IMapper>();

            var EmployeeService = new EmployeeService(EmployeeRepositoryMock.Object, MapperMock.Object);

            await EmployeeService.GetRoles();

            EmployeeRepositoryMock.Verify(x => x.GetRoles(), Times.Once);
        }
    }
}
