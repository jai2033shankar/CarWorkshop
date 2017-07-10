using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;

namespace CarWorkshop.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IClientService _client;
        private readonly IEmployeeService _employee;

        public SearchController(IClientService client, IEmployeeService employee)
        {
            _client = client;
            _employee = employee;
        }

        public async Task<IActionResult> Index(string query, string option, bool inactive)
        {
            var test1 = await _client.GetAllClients();
            var test2 = await _employee.GetAllEmployees();

            return View();
        }
    }
}