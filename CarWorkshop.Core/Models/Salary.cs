using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Salary
    {
        public Salary()
        {
            Employee = new HashSet<Employee>();
        }

        public int SalaryId { get; set; }
        public decimal Salary1 { get; set; }
        public string Currency { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
