using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Repair = new HashSet<Repair>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Pesel { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int Salary { get; set; }
        public int Position { get; set; }

        public virtual ICollection<Repair> Repair { get; set; }
        public virtual Position PositionNavigation { get; set; }
        public virtual Salary SalaryNavigation { get; set; }
    }
}
