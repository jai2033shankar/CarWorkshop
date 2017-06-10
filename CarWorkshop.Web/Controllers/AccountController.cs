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
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

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


                var user = await _clientService.GetClient(model.EmailAddress);

                var claims = new[]
                {
                    new Claim("TestClaim", user.EmailAddress),
                    new Claim(ClaimTypes.Role, user.UserRole)
                };

                var principal = new ClaimsPrincipal(
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                await HttpContext.Authentication.SignInAsync("CookieAuthMiddleware", principal);

                var testAccount = new AccountModel(user.EmailAddress, true);

                return View("Index");

            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.Authentication.SignOutAsync("CookieAuthMiddleware");

            return View("Index");
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
