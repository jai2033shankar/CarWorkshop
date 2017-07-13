using CarWorkshop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using CarWorkshop.Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using CarWorkshop.Infrastructure.Commands.Client;
using CarWorkshop.Infrastructure.Commands;

namespace CarWorkshop.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;
        private readonly ICommandDispatcher _dispatcher;

        public AccountController(IClientService clientService, ICommandDispatcher dispatcher, IEmployeeService employeeService)
        {
            _clientService = clientService;
            _dispatcher = dispatcher;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            if (HttpContext.User.HasClaim(x => x.Type == ClaimTypes.Name))
            {
                string test = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).SingleOrDefault();
                var user = await _clientService.GetClient(test);
                if (user == null)
                    ViewData["username"] = "XXX";
                else
                    ViewData["username"] = user.FirstName;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateClient command)
        {
            if (ModelState.IsValid)
            {
                await _dispatcher.Dispatch(command);

                return RedirectToAction("Index");
            }
           
            // If we got this far something failed. Redisplay form.
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if(ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            // Something failed.
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.Authentication.SignOutAsync("CookieAuthMiddleware");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Unauthorized()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "TestPolicy")]
        public async Task<IActionResult> Profile()
        {
            if (HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value == "TestClaim" )
            {
                var email = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value;

                var user = await _clientService.GetClient(email);

                return View(user);
            }

            // Something failed
            return View("Index");
        }

        [HttpPost]
        [Authorize(Policy = "TestPolicy")]

        public async Task<IActionResult> Profile(ClientDTO client)
        {
            await _clientService.UpdateClient(client);

            return View("Index");
        }
    }
}
