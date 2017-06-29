﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarWorkshop.Core.Models;

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
        public async Task<IActionResult> AddEmployee()
        {
            var salaries = await _employeeService.GetSalaries();
            //salaries.OrderBy(v => v.Salary1).Select(x => new { Id = x.SalaryId, Salary = x.Salary1 });
            var positions = await _employeeService.GetPositions();
            //positions.Select(x => new { Id = x.PositionId, Position = x.Description });
            var model = new AddEmployeeViewModel();
            model.Salaries = new SelectList(
                                    salaries.OrderBy(v => v.Salary1)
                                            .Select(x => new { Id = x.SalaryId, Salary = x.Salary1 })
                                            , "Id", "Salary");

            model.Positions = new SelectList(
                                    positions.Select(x => new { Id = x.PositionId, Position = x.Description })
                                             , "Id", "Position");
           
            return View(model);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                // Dirty way - change later
                var emp = new Employee { 
                    EmailAddress = employee.EmailAddress,
                    EmploymentDate = DateTime.UtcNow,
                    Position = employee.Position,
                    Salary = employee.Salary,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    IdentityCardNumber = employee.IdentityCardNumber,
                    Pesel = employee.PESEL,
                    PhoneNumber = employee.PhoneNumber
                };
                
                _employeeService.AddEmployee(emp);


                // Change later to some nice screen that says stuff went well
                return RedirectToAction("Index");
            }

            // Redisplay from something failed.
            return View();
        }
    }
}
