using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Repair
    {
        public int RepairId { get; set; }
        public int CarId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
