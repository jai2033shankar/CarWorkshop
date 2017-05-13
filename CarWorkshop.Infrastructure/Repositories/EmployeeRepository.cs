using CarWorkshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarWorkshop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CarWorkshopContext _context;
        private DbSet<Employee> employees;
        private DbSet<Salary> salaries;
        private DbSet<Position> positions;

        public EmployeeRepository(CarWorkshopContext context)
        {
            _context = context;
            employees = _context.Set<Employee>();
            salaries = _context.Set<Salary>();
            positions = _context.Set<Position>();
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee");
            }

            employees.Add(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees.AsEnumerable();
        }

        public Employee GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int Id)
            => employees.Single(e => e.EmployeeId == Id);

        public Decimal GetSalary(Employee employee)
        {
            Salary salary = salaries.Single(s => s.SalaryId == employee.Salary);

            return salary.Salary1;
        }

        public string GetPosition(Employee employee)
        {
            Position position = positions.Single(p => p.PositionId == employee.Position);

            return position.Description;
        }

        public void RemoveEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
