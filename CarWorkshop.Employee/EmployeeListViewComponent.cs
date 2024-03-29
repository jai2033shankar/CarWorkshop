﻿using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Web.ViewComponents
{
    public class EmployeeListViewComponent : ViewComponent
    {
        private readonly IEmployeeService _service;

        public EmployeeListViewComponent(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var employees = await _service.GetAllEmployees();

            return View(employees);
        }
    }
}
