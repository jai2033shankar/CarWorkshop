using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWorkshop.Infrastructure.Commands.Client
{
    public class CreateClient : ICommand
    {
        [Required(ErrorMessage = "First Name is required"), MaxLength(128)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), MaxLength(128)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "ID number is required")]
        public string IdentityCardNumber { get; set; }

        [Required(ErrorMessage = "Pesel is required")]
        public string PESEL { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address is required"), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
