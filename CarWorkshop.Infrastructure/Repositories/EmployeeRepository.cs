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
        private readonly DbSet<Position> positions;

        public EmployeeRepository(CarWorkshopContext context)
        {
            _context = context;
            employees = _context.Set<Employee>();
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
            return employees.Include(x => x.PositionNavigation).AsEnumerable();
        }

        public Employee GetEmployee(string email)
        {
            return employees.Include(x => x.PositionNavigation).Single(x => x.EmailAddress == email);
        }

        public Employee GetEmployee(int Id)
            => employees.Single(e => e.EmployeeId == Id);

        public List<Position> GetPositions()
        {
            return positions.ToList();
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
