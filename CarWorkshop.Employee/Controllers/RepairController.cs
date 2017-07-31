using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.DTO;

namespace CarWorkshop.Employee.Controllers
{
    public class RepairController : Controller
    {
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
        public async Task<IActionResult> Add(RepairDTO model)
        {
            if (ModelState.IsValid)
            {
                // ... 
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            // ...
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RepairDTO model)
        {
            if (ModelState.IsValid)
            {
                // ... 
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
