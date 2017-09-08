using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.DTO
{
    public class RepairDTO
    {
        public decimal Payment
        {
            get => Price * (1 - (Discount / 100));
            //set => Payment = Price * (1 - (Discount / 100));
        }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
        public int RepairId { get; set; }
        public int CarId { get; set; }

        public int EmployeeId { get; set; }

    }
}
