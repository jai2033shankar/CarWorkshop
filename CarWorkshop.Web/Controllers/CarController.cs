using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Web.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get(int clientId)
        {
            return View(/*Here be cars*/);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Object model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int carId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Object model)
        {
            return RedirectToAction("Index");
        }
    }
}
