using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;
using Microsoft.AspNetCore.Http;

namespace CarWorkshop.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IClientService _service;

        public CarController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int clientId)
        {
            var client = await _service.GetClient(clientId);
            var clientCars = client.Cars;

            return View(clientCars);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarDTO model)
        {
            if (ModelState.IsValid)
            {
                // Add null checking here.
                model.ClientId = (int)HttpContext.Session.GetInt32("ClientId");

                await _service.AddCar(model);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int carId)
        {
            var id = (int)HttpContext.Session.GetInt32("ClientId");
            var client = await _service.GetClient(id);
            var car = client.Cars.SingleOrDefault(c => c.CarId == carId);



            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(CarDTO model)
        {
            if (ModelState.IsValid)
            {
                // UpdateCar
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
