using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.DTO
{
    public class ClientDTO
    {
        public Guid ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IDCardNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
