using CarWorkshop.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Web.Models
{
    public class AddEmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string PESEL { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int Salary { get; set; }
        public int Position { get; set; }

        public SelectList Salaries { get; set; }
        public SelectList Positions { get; set; }
    }
}
