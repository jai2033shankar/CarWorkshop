using CarWorkshop.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.Models
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string PESEL { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal Salary { get; set; }

        [StringLength(3, ErrorMessage = "Please enter three digit code for currency.")]
        public string Currency { get; set; }
        public int Position { get; set; }
        public int UserRole { get; set; }
        public SelectList Positions { get; set; }
        public SelectList Roles { get; set; }
    }
}
