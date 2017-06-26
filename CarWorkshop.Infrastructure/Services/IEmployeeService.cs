using CarWorkshop.Core.Models;
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
        void AddEmployee(EmployeeDTO employee);
        List<Salary> GetSalaries();
        List<Position> GetPositions();
    }
}
