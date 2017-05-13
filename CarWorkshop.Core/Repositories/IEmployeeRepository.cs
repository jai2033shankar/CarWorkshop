using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Models;

namespace CarWorkshop.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int Id);

        Employee GetEmployeeByEmail(string email);

        IEnumerable<Employee> GetAllEmployees();

        Decimal GetSalary(Employee employee);

        string GetPosition(Employee employee);

        void AddEmployee(Employee employee);

        void RemoveEmployee(int Id);

        void UpdateEmployee(Employee employee);

    }
}
