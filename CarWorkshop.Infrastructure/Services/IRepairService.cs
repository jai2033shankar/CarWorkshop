using CarWorkshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public interface IRepairService
    {
        Task<IEnumerable<RepairDTO>> GetAllRepairs();
    }
}
