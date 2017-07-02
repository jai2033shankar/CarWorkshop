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

namespace CarWorkshop.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IClientService _clientService;

        public AccountController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //test
            if (HttpContext.User.HasClaim(x => x.Type == ClaimTypes.Name))
            {
                string test = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).SingleOrDefault();
                var user = await _clientService.GetClient(test);
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Change to automapper later.
                ClientDTO client = new ClientDTO
                {
                    EmailAddress = model.EmailAddress,
                    FirstName = model.FirstName,
                    IdentityCardNumber = model.IdentityCardNumber,
                    LastName = model.LastName,
                    Password = model.Password,
                    Pesel = model.PESEL,
                    PhoneNumber = model.PhoneNumber,
                    UserRole = "Client"
                };

                await _clientService.AddClient(client);

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
                ClientDTO user = await _clientService.GetClient(model.EmailAddress);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "TestClaim"),
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.Role, user.UserRole)
                };

                var principal = new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                await HttpContext.Authentication.SignInAsync("CookieAuthMiddleware", principal);


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
        public async Task<IActionResult> Profile(ClientDTO client)
        {
            await _clientService.UpdateClient(client);

            return View("Index");
        }
    }
}
