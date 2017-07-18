using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Models;
using System.Threading.Tasks;

namespace CarWorkshop.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int Id);

        Task<Employee> GetEmployee(string email);

        Task<IEnumerable<Employee>> GetAllEmployees();

        Task AddEmployee(Employee employee);

        Task RemoveEmployee(int Id);

        Task UpdateEmployee(Employee employee);

        Task<List<Position>> GetPositions();
    }
}
