using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;

        public AccountService(IClientService clientService, IEmployeeService employeeService)
        {
            _clientService = clientService;
            _employeeService = employeeService;
        }

        public async Task LoginUser(string email, string password)
        {
            // Change dis shit when werks
            var user = await _clientService.GetClient(email);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "TestClaim"),
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.Role, user.UserRole),
                };
            }
            else
            {
                var user1 = await _employeeService.GetEmployee(email);

                var claims = new[]
{
                    new Claim(ClaimTypes.Name, "TestClaim"),
                    new Claim(ClaimTypes.Email, user1.EmailAddress),
                    new Claim(ClaimTypes.Role, user1.UserRole)
                };
            }

            



        }
    }
}
