using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class CarModel
    {
        public CarModel()
        {
            Car = new HashSet<Car>();
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual CarBrand Brand { get; set; }
    }
}
