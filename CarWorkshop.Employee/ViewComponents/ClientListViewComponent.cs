using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.ViewComponents
{
    public class ClientListViewComponent : ViewComponent
    {
        private readonly IClientService _service;

        public ClientListViewComponent(IClientService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool inactive)
        {
            var clients = await _service.GetAllClients();

            return View(clients);
        }
    }
}
