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
        private readonly DbSet<Repair> _repairs;
        public RepairRepository(CarWorkshopContext context)
        {
            _context = context;
            _repairs = _context.Set<Repair>();
        }

        public async Task AddRepair(Repair repair)
        {
            await _repairs.AddAsync(repair);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Repair>> GetAllRepairs()
        {
            var result = await _repairs.Include(c => c.Car).Include(c => c.Employee).ToListAsync();

            return result;
        }

        public async Task UpdateRepair(Repair updatedRepair)
        {
            _repairs.Update(updatedRepair);

            await _context.SaveChangesAsync();
        }

        public async Task<Repair> GetRepair(int repairId)
        {
            Repair repair = await _repairs.SingleOrDefaultAsync(c => c.RepairId == repairId);

            if (repair == null)
            {
                throw new Exception($"Repair with Id:{repairId} could not be found.");
            }

            return repair;
        }
    }
}
