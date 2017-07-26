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
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            foreach(var employee in await _employeeRepository.GetAllEmployees())
            {
                employees.Add(_mapper.Map<Employee, EmployeeDTO>(employee)); 
            }

            return employees;
        }

        public async Task<EmployeeDTO> GetEmployee(int Id)
        {
            Employee employee = await _employeeRepository.GetEmployee(Id);

            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public async Task AddEmployee(EmployeeDTO employee)
        {
            Employee newEmployee = _mapper.Map<EmployeeDTO, Employee>(employee);

            await _employeeRepository.AddEmployee(newEmployee);

        }
       
        public async Task<List<Position>> GetPositions()
        {
            return await _employeeRepository.GetPositions();
        }

        public async Task<EmployeeDTO> GetEmployee(string email)
        {
            Employee employee = await _employeeRepository.GetEmployee(email);

            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public async Task UpdateEmployee(EmployeeDTO updatedEmployee)
        {
            Employee EmployeeToUpdate = await _employeeRepository.GetEmployee(updatedEmployee.EmployeeId);

            _mapper.Map(updatedEmployee, EmployeeToUpdate);

            await _employeeRepository.UpdateEmployee(EmployeeToUpdate);
        }
    }
}
