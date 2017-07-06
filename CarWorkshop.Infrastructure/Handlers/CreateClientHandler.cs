using AutoMapper;
using CarWorkshop.Infrastructure.Commands;
using CarWorkshop.Infrastructure.Commands.Client;
using CarWorkshop.Infrastructure.DTO;
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
        private readonly IMapper _mapper;

        public CreateClientHandler(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        public async Task Handle(CreateClient command)
        {
            ClientDTO client = _mapper.Map<CreateClient, ClientDTO>(command);

            await _clientService.AddClient(client);
        }
    }
}
