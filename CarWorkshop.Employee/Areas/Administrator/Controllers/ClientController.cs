using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Infrastructure.Services;

namespace CarWorkshop.Employee.Controllers
{
    [Area("Administrator")]
    public class ClientController : Controller
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClientDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddClient(model);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            ClientDTO client = await _service.GetClient(Id);

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateClient(model);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            return View();
        }
    }
}
