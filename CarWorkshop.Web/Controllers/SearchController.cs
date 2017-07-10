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

        [HttpGet]
        public async Task<IActionResult> Index(string query, string option, bool inactive)
        {
            switch(option)
            {
                case "clients":
                    ViewData["test"] = "clients";
                    break;

                case "employees":
                    ViewData["test"] = "employees";
                    break;

                case "cars":
                    ViewData["test"] = "cars";
                    break;

                case "repairs":
                    ViewData["test"] = "repairs";
                    break;

                default:
                    ViewData["test"] = "default";
                    break;
            }

            return View();
        }
    }
}