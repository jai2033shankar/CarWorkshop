using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.ViewComponents
{
    public class CarListViewComponent : ViewComponent
    {
        private readonly ICarService _service;

        public CarListViewComponent(ICarService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool inactive, int clientId, int? page)
        {
            var cars = await _service.GetAllCars();

            if (clientId > 0 )
            {
                cars = cars.Where(car => car.ClientId == clientId).ToList();
            }

            int pageSize = 5;

            return View(await PaginatedList<CarDTO>.CreateList(cars.AsQueryable(), page ?? 1, pageSize)); 
        }
    }
}
