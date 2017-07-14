using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string query, string option, bool inactive)
        {
            if (option != null)
            {
                ViewData["ViewComponent"] = option;
            }


            return View();
        }
    }
}