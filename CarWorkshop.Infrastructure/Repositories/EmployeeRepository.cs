using CarWorkshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarWorkshop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CarWorkshopContext _context;
        private readonly DbSet<Employee> employees;
        private readonly DbSet<Position> positions;
        private readonly DbSet<UserRole> roles;

        public EmployeeRepository(CarWorkshopContext context)
        {
            _context = context;
            employees = _context.Set<Employee>();
            positions = _context.Set<Position>();
            roles = _context.Set<UserRole>();
        }

        public async Task AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("AddEmployee received null Employee object.");
            }

            await employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            IEnumerable<Employee> allEmployees = await employees.Include(x => x.PositionNavigation)
                .Include(x => x.UserRoleNavigation).ToListAsync();

            if (allEmployees == null)
            {
                throw new Exception("Could not retrieve employees from database");
            }

            return allEmployees;
        }

        public async Task<Employee> GetEmployee(string email)
        {
            Employee employee = await employees.Include(x => x.PositionNavigation)
                                                .Include(x => x.UserRoleNavigation)
                                               .SingleOrDefaultAsync(x => x.EmailAddress == email);

            if (employee == null)
            {
                throw new Exception($"Employee with given email address: ${email} could not be found.");
            }

            return employee;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            Employee employee = await employees.Include(x => x.PositionNavigation)
                .Include(x => x.UserRoleNavigation)
                                               .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee == null)
            {
                throw new Exception($"Employee with given id: {employeeId} could not be found.");
            }

            return employee;
        }


        public async Task RemoveEmployee(int Id)
        {
            Employee employeeToDelete = await employees.SingleOrDefaultAsync(x => x.EmployeeId == Id);


            if (employeeToDelete == null)
            {
                throw new Exception("Employee not found");
            }

            _context.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("We got null here.");
            }

            _context.Update(employee);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Position>> GetPositions()
        {
            return await positions.ToListAsync();
        }

        public async Task<List<UserRole>> GetRoles()
        {
            return await roles.ToListAsync();
        }

    }
}
