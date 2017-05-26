using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Infrastructure.DTO;

namespace CarWorkshop.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IClientService _client;
        public TestController(IClientService client)
        {
            _client = client;
        }

        [HttpGet]
        public ClientDTO Index()
        {
            return _client.GetClient(2);
        }

    }
}
