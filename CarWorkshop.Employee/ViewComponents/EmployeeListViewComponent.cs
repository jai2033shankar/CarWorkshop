using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.ViewComponents
{
    public class EmployeeListViewComponent : ViewComponent
    {
        private readonly IEmployeeService _service;

        public EmployeeListViewComponent(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool inactive, int? page)
        {
            var employees = await _service.GetAllEmployees();
            int pageSize = 5;

            return View(await PaginatedList<EmployeeDTO>.CreateList(employees.AsQueryable(), page ?? 1, pageSize));
        }
    }
}
