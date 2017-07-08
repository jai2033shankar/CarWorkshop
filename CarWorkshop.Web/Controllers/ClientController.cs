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
using CarWorkshop.Infrastructure.Queries;
using CarWorkshop.Infrastructure.Queries.Client;

namespace CarWorkshop.Web.Controllers
{
    [Authorize(Policy = "TestPolicy")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ICommandDispatcher _dispatcher;

        private readonly IQueryHandler<FindClientsByKey, Task<ClientDTO>> _handler;

        private readonly IQueryProcessor _queryProcessor;

        public ClientController(IClientService clientService, ICommandDispatcher dispatcher, IQueryProcessor queryProcessor)
        {
            _clientService = clientService;
            _dispatcher = dispatcher;
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public  async Task<IActionResult> GetClient(ClientSearchViewModel clientSearch)
        {
            var query = new FindClientsByKey { EmailAddress = clientSearch.Email, ID = clientSearch.Id };

            return View(await _queryProcessor.Process(query));
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
