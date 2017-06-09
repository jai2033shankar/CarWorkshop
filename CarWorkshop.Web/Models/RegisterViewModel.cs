using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Web.Models
{
    public class RegisterViewModel
    {
        [Required, MaxLength(128)]
        public string FirstName { get; set; }

        [Required, MaxLength(128)]
        public string LastName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public string IdentityCardNumber { get; set; }

        [Required]
        public string PESEL { get; set; }

        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
