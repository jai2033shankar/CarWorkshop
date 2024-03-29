﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CarWorkshop.Employee.Controllers
{
    [Authorize()]
    [Area("Administrator")]

    public class SearchController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string option, bool inactive, int? page)
        {
            switch(option)
            {
                case "ClientList":
                    ViewData["ViewComponent"] = option;
                    break;

                case "EmployeeList":
                    ViewData["ViewComponent"] = option;
                    break;

                case "CarList":
                    ViewData["ViewComponent"] = option;
                    break;

                case "RepairList":
                    ViewData["ViewComponent"] = option;
                    break;

                default:
                    ViewData["WrongOption"] = "Please select valid option";
                    break;
            }

            ViewData["Inactive"] = inactive;
            ViewData["CurrentListPage"] = page ?? 1;

            return View();
        }
    }
}
