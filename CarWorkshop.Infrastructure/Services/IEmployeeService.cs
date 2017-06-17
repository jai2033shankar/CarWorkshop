using CarWorkshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.Services
{
    public interface IEmployeeService
    {
        EmployeeDTO GetEmployeeById(int Id);
        IEnumerable<EmployeeDTO> GetAllEmployees();
    }
}
