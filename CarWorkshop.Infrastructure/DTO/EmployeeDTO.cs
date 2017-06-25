using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.DTO
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Pesel { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public SalaryDTO Salary { get; set; }
        public string Position { get; set; }

    }
}
