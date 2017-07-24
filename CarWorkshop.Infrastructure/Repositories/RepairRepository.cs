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

        public async Task AddRepair(Repair repair)
        {
            await repairs.AddAsync(repair);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Repair>> GetAllRepairs()
        {
            repairs.Include(c => c.Car).Include(c => c.Employee);

            return await repairs.ToListAsync();
        }

        public async Task UpdateRepair(Repair updatedRepair)
        {
            repairs.Update(updatedRepair);

            await _context.SaveChangesAsync();
        }
    }
}
