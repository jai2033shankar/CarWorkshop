using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Web.Models;
using CarWorkshop.Infrastructure.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using CarWorkshop.Infrastructure.Commands.Client;
using CarWorkshop.Infrastructure.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CarWorkshop.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ICommandDispatcher _dispatcher;

        public HomeController(IClientService clientService, ICommandDispatcher dispatcher)
        {
            _clientService = clientService;
            _dispatcher = dispatcher;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            // Move logic into command

            if (ModelState.IsValid)
            {
                var client = await _clientService.GetClient(model.EmailAddress);

                // Weird bug here - client.Password has a lot of white space.
                if (client == null || client.Password.Trim() != model.Password)
                {
                    // Show error
                    throw new Exception("Stuff went very wrong");
                }

                var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, "TestClaim"),
                        new Claim(ClaimTypes.Email, client.EmailAddress),
                        new Claim(ClaimTypes.Role, client.UserRole)
                    };

                var principal = new ClaimsPrincipal(
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                HttpContext.Session.SetInt32("ClientId", client.ClientId);

                await HttpContext.Authentication.SignInAsync("CookieAuthMiddleware", principal);
            }

            // If we got this far something failed. Redisplay form.
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.Authentication.SignOutAsync("CookieAuthMiddleware");

            return View("Index");
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateClient command)
        {
            if (ModelState.IsValid)
            {
                await _dispatcher.Dispatch(command);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
