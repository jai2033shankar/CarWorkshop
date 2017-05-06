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

    }
}
