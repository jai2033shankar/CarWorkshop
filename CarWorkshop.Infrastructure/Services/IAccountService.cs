using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public interface IAccountService
    {
        Task LoginUser(string email, string password);
    }
}
