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
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public decimal? Payment { get; set; }
        public virtual Car Car { get; set; }
        public virtual Discount DiscountNavigation { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
