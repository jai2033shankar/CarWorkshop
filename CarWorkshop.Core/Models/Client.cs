using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Client
    {
        public Client()
        {
            Car = new HashSet<Car>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Car> Car { get; set; }
    }
}
