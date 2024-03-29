﻿using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Core.Models;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;

namespace CarWorkshop.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidationService _validator;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper,
            IValidationService validator)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _validator = validator;
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

            newEmployee.EmploymentDate = DateTime.UtcNow;

            if (!await _validator.ValidateIdNumber(newEmployee.IdentityCardNumber))
            {
                throw new Exception("Wrong ID NUMBER");
            }

            if (!await _validator.ValidatePesel(newEmployee.Pesel))
            {
                throw new Exception("Wrong pesel");
            }

            await _employeeRepository.AddEmployee(newEmployee);

        }
       
        public async Task<List<Position>> GetPositions()
        {
            return await _employeeRepository.GetPositions();
        }

        public async Task<List<UserRole>> GetRoles()
        {
            var result = await _employeeRepository.GetRoles();
            return result.Where(x => x.Name != "Client").ToList();
        }

        public async Task<EmployeeDTO> GetEmployee(string email)
        {
            Employee employee = await _employeeRepository.GetEmployee(email);

            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public async Task UpdateEmployee(EmployeeDTO updatedEmployee) 
        {
            Employee EmployeeToUpdate = await _employeeRepository
                .GetEmployee(updatedEmployee.EmployeeId);

            _mapper.Map(updatedEmployee, EmployeeToUpdate);

            await _employeeRepository.UpdateEmployee(EmployeeToUpdate);
        }

        public async Task RemoveEmployee(int Id)
        {
            await _employeeRepository.RemoveEmployee(Id);
        }
    }
}
