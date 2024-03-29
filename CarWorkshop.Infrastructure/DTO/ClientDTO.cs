﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.DTO
{
    public class ClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }

        public List<CarDTO> Cars { get; set; }

    }
}
