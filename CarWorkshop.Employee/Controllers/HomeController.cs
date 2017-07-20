using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Employee.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CarWorkshop.Employee.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IEmployeeService _service;
        public HomeController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: Login
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = await _service.GetEmployee(model.EmailAddress);
                
                if (employee == null)
                {
                    throw new Exception("No such employee");
                }

                if (model.Password != employee.Password.Trim())
                {
                    return RedirectToAction("Index");
                }
                
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "EmployeeAuthClaim"),
                    new Claim(ClaimTypes.Email, model.EmailAddress),
                    new Claim(ClaimTypes.Role, employee.UserRole)
                };

                var principal = new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                await HttpContext.Authentication.SignInAsync("EmployeeAuthCookieMiddleware", principal);

                return RedirectToAction("Index");
            }

            // Something went wrong, redisplay form.
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.Authentication.SignOutAsync("EmployeeAuthCookieMiddleware");

            return View("Index");
        }

        [HttpGet]
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
