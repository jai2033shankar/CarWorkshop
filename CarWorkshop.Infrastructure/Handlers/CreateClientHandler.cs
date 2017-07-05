using CarWorkshop.Infrastructure.Commands;
using CarWorkshop.Infrastructure.Commands.Client;
using CarWorkshop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Handlers
{
    public class CreateClientHandler : ICommandHandler<CreateClient>
    {
        private readonly IClientService _clientService;

        public CreateClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task Handle(CreateClient command)
        {

            // To do.
            await Task.CompletedTask;
        }
    }
}
