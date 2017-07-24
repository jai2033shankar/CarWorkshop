using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Employee.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string query, string option, bool inactive)
        {
            if (!String.IsNullOrEmpty(option))
            {
                ViewData["ViewComponent"] = option;
                ViewData["Query"] = query;
                ViewData["Inactive"] = inactive;
            }

            return View();
        }
    }
}
