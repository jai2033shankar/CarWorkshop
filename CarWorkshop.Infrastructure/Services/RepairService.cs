using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Infrastructure.DTO;
using CarWorkshop.Core.Repositories;
using AutoMapper;
using CarWorkshop.Core.Models;

namespace CarWorkshop.Infrastructure.Services
{
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repository;
        private readonly IMapper _mapper;
        public RepairService(IRepairRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddRepair(RepairDTO repair)
        {
            Repair newRepair = _mapper.Map<RepairDTO, Repair>(repair);

            await _repository.AddRepair(newRepair);
        }

        public async Task<IEnumerable<RepairDTO>> GetAllRepairs()
        {
            var repairs = await _repository.GetAllRepairs();

            IEnumerable<RepairDTO> result = _mapper.Map<IEnumerable<Repair>, IEnumerable<RepairDTO>>(repairs);

            return result;
        }

        public async Task UpdateRepair(RepairDTO updatedRepair)
        {
            Repair repairToUpdate = await _repository.GetRepair(updatedRepair.RepairId);

            _mapper.Map(updatedRepair, repairToUpdate);

            await _repository.UpdateRepair(repairToUpdate);
        }

        public async Task<RepairDTO> GetRepair(int repairId)
        {
            RepairDTO repair = _mapper.Map<Repair,RepairDTO>(await _repository.GetRepair(repairId));

            return repair;
        }

        public async Task RemoveRepair(int Id)
        {
            await _repository.RemoveRepair(Id);
        }
    }
}
