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
        Task<EmployeeDTO> GetEmployee(int Id);
        Task<EmployeeDTO> GetEmployee(string email);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<Boolean> AddEmployee(Employee employee);
        Task<List<Position>> GetPositions();
    }
}
