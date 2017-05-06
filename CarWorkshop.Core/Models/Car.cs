using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Core.Models
{
    public class Car
    {
        public Guid ID { get; protected set; }

        public string Brand { get; protected set; }

        public string Model { get; protected set; }

        public IEnumerable<Repair> Repairs;
    }
}
