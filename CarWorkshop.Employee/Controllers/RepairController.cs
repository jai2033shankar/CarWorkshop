﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace CarWorkshop.Employee.Controllers
{
    public class RepairController : Controller
    {
        private readonly IRepairService _service;

        public RepairController(IRepairService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(int CarId)
        {
            RepairDTO newRepair = new RepairDTO();

            newRepair.CarId = CarId;

            return View(newRepair);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RepairDTO model)
        {
            if (ModelState.IsValid)
            {
                model.EmployeeId = (int)HttpContext.Session.GetInt32("EmployeeId");
                await _service.AddRepair(model);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            RepairDTO repair = await _service.GetRepair(Id);

            return View(repair);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RepairDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateRepair(model);
                
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            await _service.RemoveRepair(Id);

            return View("Index");
        }
    }
}
