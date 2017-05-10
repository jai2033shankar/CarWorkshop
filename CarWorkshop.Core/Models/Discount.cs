using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Discount
    {
        public int DiscountId { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
