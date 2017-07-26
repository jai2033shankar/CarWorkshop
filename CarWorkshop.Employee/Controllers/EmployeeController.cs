using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarWorkshop.Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddEmployee(model);

                return RedirectToAction("Index");
            }

            // Something failed redisplay form.
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            EmployeeDTO employee = await _service.GetEmployee(Id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateEmployee(model);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
