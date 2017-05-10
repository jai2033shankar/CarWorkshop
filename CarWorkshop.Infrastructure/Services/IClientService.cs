using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;

namespace CarWorkshop.Infrastructure.Services
{
    public interface IClientService
    {
        ClientDTO GetClient(int ID);
    }
}
