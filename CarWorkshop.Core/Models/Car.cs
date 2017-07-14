using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Car
    {
        public Car()
        {
            Repair = new HashSet<Repair>();
        }

        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public int? ClientId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public virtual ICollection<Repair> Repair { get; set; }
        public virtual Client Client { get; set; }
    }
}
