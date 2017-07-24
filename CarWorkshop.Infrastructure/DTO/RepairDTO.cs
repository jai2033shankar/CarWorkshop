using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.DTO
{
    public class RepairDTO
    {
        public decimal Payment { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
        public int RepairId { get; set; }

    }
}
