using CarWorkshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Core.Repositories
{
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetAllRepairs();

        Task AddRepair(int carId, int employeeId);

        Task UpdateRepair(Repair updatedRepair);
    }
}
