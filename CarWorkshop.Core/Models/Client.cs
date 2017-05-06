using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Core.Models
{
    public class Client : User
    {
        public IEnumerable<Car> Cars;
        
        protected Client()
        {
            
        }
    }
}
