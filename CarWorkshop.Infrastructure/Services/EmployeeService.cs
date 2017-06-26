using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;
using AutoMapper;

namespace CarWorkshop.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = new List<EmployeeDTO>();

            foreach(var employee in _employeeRepository.GetAllEmployees())
            {
                employees.Add(_mapper.Map<Employee, EmployeeDTO>(employee)); 
            }

            return employees;
        }

        public EmployeeDTO GetEmployeeById(int Id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(Id);

            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            Employee emp = _mapper.Map<EmployeeDTO, Employee>(employee);
            _employeeRepository.AddEmployee(emp);
        }
        // temp solution
        public List<Salary> GetSalaries()
        {
            return _employeeRepository.GetSalaries();
        }

        public List<Position> GetPositions()
        {
            return _employeeRepository.GetPositions();
        }
    }
}
