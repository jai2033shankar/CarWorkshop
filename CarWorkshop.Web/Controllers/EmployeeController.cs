using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWorkshop.Web.Controllers
{
    [Authorize(Policy = "TestPolicy")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return View(_employeeService.GetAllEmployees());
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            var salaries = _employeeService.GetSalaries().OrderBy(v => v.Salary1).Select(x => new { Id = x.SalaryId, Salary = x.Salary1 });
            var positions = _employeeService.GetPositions().Select(x => new { Id = x.PositionId, Position = x.Description });
            var model = new AddEmployeeViewModel();
            model.Salaries = new SelectList(salaries, "Id", "Salary");
            model.Positions = new SelectList(positions, "Id", "Position");
           
            return View(model);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                //_employeeService.AddEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
