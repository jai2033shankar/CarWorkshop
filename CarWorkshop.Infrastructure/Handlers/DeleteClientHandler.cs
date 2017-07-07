using CarWorkshop.Infrastructure.Commands;
using CarWorkshop.Infrastructure.Commands.Client;
using CarWorkshop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Handlers
{
    public class DeleteClientHandler : ICommandHandler<DeleteClient>
    {
        private readonly IClientService _service;
        public DeleteClientHandler(IClientService service)
        {
            _service = service;
        }
        public async Task Handle(DeleteClient command)
        {
            await _service.RemoveClient(command.Id);
        }
    }
}
