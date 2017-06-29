using AutoMapper;
using CarWorkshop.Core.Repositories;
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

            var MapperMock = new Mock<IMapper>();
            var ClientService = new ClientService(ClientRepositoryMock.Object, MapperMock.Object);
            var email = "sajmon265@gmail.com";
            await ClientService.GetClient(email);
            ClientRepositoryMock.Verify(x => x.GetClientByEmail(It.IsAny<string>()), Times.Once);
        }

    }
}
