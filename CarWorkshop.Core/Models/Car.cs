using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class Car
    {
        public int CarId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public string RegistrationNumber { get; set; }
        public int ClientId { get; set; }

        public virtual CarBrand Brand { get; set; }
        public virtual Client Client { get; set; }
        public virtual CarModel Model { get; set; }
    }
}
