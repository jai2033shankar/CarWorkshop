using CarWorkshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using CarWorkshop.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly CarWorkshopContext _context;
        private readonly DbSet<Repair> repairs;
        public RepairRepository(CarWorkshopContext context)
        {
            _context = context;
            repairs = _context.Set<Repair>();
        }

        public Task AddRepair(int carId, int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Repair>> GetAllRepairs()
        {
            repairs.Include(c => c.Car).Include(c => c.Employee);

            return await repairs.ToListAsync();
        }

        public Task UpdateRepair(Repair updatedRepair)
        {
            throw new NotImplementedException();
        }
    }
}
