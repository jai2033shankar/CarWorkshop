using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Infrastructure.Services;
using System.Security.Claims;

namespace CarWorkshop.Web.Controllers
{
    public class ProfileController : Controller
    {
        IClientService _service;
        public ProfileController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                var email = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value;

                var user = await _service.GetClient(email);

                return View(user);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int clientId)
        {
            var client = await _service.GetClient(clientId);

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientDTO client)
        {
            await _service.UpdateClient(client);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int clientId)
        {
            return View();
        }
    }
}
