using CarWorkshop.Core.Models;
using CarWorkshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeById(int Id);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<Boolean> AddEmployee(Employee employee);
        Task<List<Salary>> GetSalaries();
        Task<List<Position>> GetPositions();
    }
}
