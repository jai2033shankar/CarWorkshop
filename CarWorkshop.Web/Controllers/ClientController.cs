using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Web.Models;
using Microsoft.AspNetCore.Authorization;
using CarWorkshop.Infrastructure.Commands;
using CarWorkshop.Infrastructure.Commands.Client;

namespace CarWorkshop.Web.Controllers
{
    [Authorize(Policy = "TestPolicy")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ICommandDispatcher _dispatcher;
        public ClientController(IClientService clientService, ICommandDispatcher dispatcher)
        {
            _clientService = clientService;
            _dispatcher = dispatcher;
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

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return View(await _clientService.GetAllClients());
        }

        public async Task<IActionResult> DeleteClient(DeleteClient command)
        {
            await _dispatcher.Dispatch(command);

            return RedirectToAction("GetAllClients");
        }
    }
}
