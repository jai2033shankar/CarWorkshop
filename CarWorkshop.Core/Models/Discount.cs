using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Repair = new HashSet<Repair>();
        }

        public int DiscountId { get; set; }
        public decimal DiscountPercentage { get; set; }

        public virtual ICollection<Repair> Repair { get; set; }
    }
}
