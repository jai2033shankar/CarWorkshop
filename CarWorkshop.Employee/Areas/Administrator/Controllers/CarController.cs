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
    public class CarController : Controller
    {
        private readonly ICarService _service;
        public CarController(ICarService service)
        {
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(int clientId)
        {
            CarDTO newCar = new CarDTO();
            newCar.ClientId = clientId;

            return View(newCar);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCar(model);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            CarDTO car = await _service.GetCar(Id);

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateCar(model);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            await _service.RemoveCar(Id);

            return View("Index");
        }
    }
}
