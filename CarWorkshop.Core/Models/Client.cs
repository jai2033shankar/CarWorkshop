using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Core.Models
{
    public class Client : User
    {
        public IEnumerable<Car> Cars;
        
        protected Client() :
            base()
        {
            
        }

        public Client(string firstname, string lastname, string email, string password) : 
            base(firstname, lastname, email, password)
        {

        }
    }
}
