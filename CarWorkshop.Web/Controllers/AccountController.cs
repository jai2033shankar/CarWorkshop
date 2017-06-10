using CarWorkshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Web.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Do stuff.

                return View(model);
            }

            // If we got this far something failed. Redisplay form.
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if(ModelState.IsValid)
            {
                return View(model);

            }
            return View();
        }

        public async Task<IActionResult> Unauthorized()
        {
            return View();
        }

        public async Task<IActionResult> Forbidden()
        {
            return View();
        }

    }
}
