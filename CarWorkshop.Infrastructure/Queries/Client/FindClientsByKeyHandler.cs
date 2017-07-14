using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Queries.Client
{
    public class FindClientsByKeyHandler
        : IQueryHandler<FindClientsByKey, Task<ClientDTO>>
    {

        private readonly IClientService _service;
        public FindClientsByKeyHandler(IClientService service)
        {
            _service = service;
        }

        public async Task<ClientDTO> Handle(FindClientsByKey query)
        {
            if (!String.IsNullOrEmpty(query.EmailAddress))
            {
                return await _service.GetClient(query.EmailAddress);
            }

            if (query.ID <= 0)
            {
                throw new Exception("At least one parameter must be valid!");
            }

            return await _service.GetClient(query.ID);


        }
    }
}
