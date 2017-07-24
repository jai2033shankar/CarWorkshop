using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.ViewComponents
{
    public class RepairListViewComponent : ViewComponent
    {
        private readonly IRepairService _service; 
        public RepairListViewComponent(IRepairService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string query, bool inactive)
        {
            var repairs = await _service.GetAllRepairs();

            return View(repairs);
        }
    }
}
