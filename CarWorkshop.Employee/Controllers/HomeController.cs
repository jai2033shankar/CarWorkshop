using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Employee.Models;

namespace CarWorkshop.Employee.Controllers
{
    public class HomeController : Controller
    {

        // GET: Login

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                // LogIn user

                return RedirectToAction("Index");
            }

            // Something went wrong, redisplay form.
            return RedirectToAction("Index");
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
