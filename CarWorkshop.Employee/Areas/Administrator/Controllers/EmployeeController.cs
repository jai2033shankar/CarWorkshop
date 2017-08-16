using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Employee.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarWorkshop.Employee.Controllers
{
    [Area("Administrator")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EmployeeViewModel model = new EmployeeViewModel();

            model.Positions = new SelectList(await _service.GetPositions(), "PositionId", "Description");
            model.Roles = new SelectList(await _service.GetRoles(), "RoleId", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Temporary solution.
                EmployeeDTO emp = new EmployeeDTO
                {
                    Currency = "PLN",
                    EmailAddress = model.EmailAddress,
                    EmploymentDate = model.EmploymentDate,
                    FirstName = model.FirstName,
                    IdentityCardNumber = model.IdentityCardNumber,
                    LastName = model.LastName,
                    PESEL = model.PESEL,
                    PhoneNumber = model.PhoneNumber,
                    Position = model.Position.ToString(),
                    Salary = model.Salary,
                    UserRole = model.UserRole.ToString()
                };

                await _service.AddEmployee(emp);

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
