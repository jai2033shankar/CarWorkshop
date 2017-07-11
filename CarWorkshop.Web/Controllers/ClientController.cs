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

        public async Task<IActionResult> DeleteClient(DeleteClient command)
        {
            await _dispatcher.Dispatch(command);

            return RedirectToAction("GetAllClients");
        }
    }
}
