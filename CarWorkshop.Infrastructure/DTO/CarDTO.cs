using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.DTO
{
    public class CarDTO
    {
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string CarModel { get; set; }
        public string RegistrationNumber { get; set; }
        public List<RepairDTO> Repair { get; set; }
    }
}
