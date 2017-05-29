using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public interface IClientService
    {
        Task<ClientDTO> GetClient(int ID);

        ClientDTO GetAllClients();
    }
}
