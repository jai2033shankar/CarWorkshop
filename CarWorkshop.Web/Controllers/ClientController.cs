using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarWorkshop.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public  async Task<IActionResult> GetClient(ClientSearchViewModel clientSearch)
        {

        if (!String.IsNullOrEmpty(clientSearch.Email))
        {
            return View(await _clientService.GetClient(clientSearch.Email));
        }

        if (clientSearch.Id > 0)
        {
            return View(await _clientService.GetClient(clientSearch.Id));

        }

            return View();
        }

        [Authorize(Policy = "TestPolicy")]
        [HttpGet]
        public IActionResult GetAllClients()
        {
            return View(_clientService.GetAllClients());
        }
    }
}
