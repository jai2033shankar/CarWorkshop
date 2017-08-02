﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;
using System.Security.Claims;

namespace CarWorkshop.Employee.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IEmployeeService _service;

        public ProfileController(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            // Add error checking.
            string email = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value;

            EmployeeDTO employee = await _service.GetEmployee(email);

            return View(employee);
        }
    }
}
