using CarWorkshop.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Web.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IdentityCardNumber { get; set; }
        [Required]
        public string PESEL { get; set; }
        [Required]
        public DateTime EmploymentDate { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int Position { get; set; }


        public SelectList Salaries { get; set; }

        public SelectList Positions { get; set; }
    }
}
