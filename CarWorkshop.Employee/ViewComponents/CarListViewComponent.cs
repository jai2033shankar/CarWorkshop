using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.ViewComponents
{
    public class CarListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string query, bool inactive)
        {
            // TODO: Implement CarService and use it here.
            return View(); 
        }
    }
}
