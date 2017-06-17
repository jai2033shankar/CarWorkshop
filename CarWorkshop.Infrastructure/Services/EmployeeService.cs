using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;

namespace CarWorkshop.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = new List<EmployeeDTO>();

            foreach(var employee in _employeeRepository.GetAllEmployees())
            {
                employees.Add(new EmployeeDTO
                {
                    EmailAddress = employee.EmailAddress,
                    EmploymentDate = employee.EmploymentDate,
                    FirstName = employee.FirstName,
                    IdentityCardNumber = employee.IdentityCardNumber,
                    LastName = employee.LastName,
                    Pesel = employee.Pesel,
                    PhoneNumber = employee.PhoneNumber,
                    Position = _employeeRepository.GetPosition(employee),
                    Salary = _employeeRepository.GetSalary(employee)
                });
            }

            return employees;
        }

        public EmployeeDTO GetEmployeeById(int Id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(Id);

            return new EmployeeDTO
            {
                EmailAddress = employee.EmailAddress,
                EmploymentDate = employee.EmploymentDate,
                FirstName = employee.FirstName,
                IdentityCardNumber = employee.IdentityCardNumber,
                LastName = employee.LastName,
                Pesel = employee.Pesel,
                PhoneNumber = employee.PhoneNumber,
                Position = _employeeRepository.GetPosition(employee),
                Salary = _employeeRepository.GetSalary(employee)
            };
        }
    }
}
