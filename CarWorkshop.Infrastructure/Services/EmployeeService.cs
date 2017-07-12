using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;
using AutoMapper;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            var employees = new List<EmployeeDTO>();

            foreach(var employee in _employeeRepository.GetAllEmployees())
            {
                employees.Add(_mapper.Map<Employee, EmployeeDTO>(employee)); 
            }

            return employees;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int Id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(Id);

            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public async Task<Boolean> AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);

            return true;
        }
       
        public async Task<List<Position>> GetPositions()
        {
            return _employeeRepository.GetPositions();
        }
    }
}
