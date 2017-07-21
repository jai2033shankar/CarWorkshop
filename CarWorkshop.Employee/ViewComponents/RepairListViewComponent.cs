using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.ViewComponents
{
    public class RepairListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string query, bool inactive)
        {
            //TODO
            return View();
        }
    }
}
