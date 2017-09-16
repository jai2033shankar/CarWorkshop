using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWorkshop.Infrastructure.DTO
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string PESEL { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal Salary { get; set; }
        public string Currency { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }
        public int UserRoleId { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }

    }
}
