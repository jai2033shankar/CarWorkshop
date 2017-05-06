using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Core.Models
{
    public class Employee : User
    {
        public string Pesel { get; protected set; }

        public DateTime EmploymentDate { get; protected set; }

        public Decimal Salary { get; protected set; }

        //TODO: Add working position

        protected Employee() : 
            base()
        {

        }

        public Employee(string firstname, string lastname, string email, string password, string pesel, Decimal salary) : 
            base(firstname, lastname, email, password)
        {
            Pesel = pesel;
            Salary = salary;
        }

    }
}
