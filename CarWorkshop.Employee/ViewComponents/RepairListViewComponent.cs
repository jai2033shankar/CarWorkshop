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

        public async Task<IViewComponentResult> InvokeAsync(string query, bool inactive, int carId)
        {
            var repairs = await _service.GetAllRepairs();

            if (carId > 0 )
            {
                repairs = repairs.Where(repair => repair.CarId == carId).ToList();
            }

            return View(repairs);
        }
    }
}
