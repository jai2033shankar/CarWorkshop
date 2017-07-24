using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Employee.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Please provide valid email."), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please provide valid password."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
