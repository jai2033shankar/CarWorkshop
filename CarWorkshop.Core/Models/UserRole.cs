using System;
using System.Collections.Generic;

namespace CarWorkshop.Core.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Client = new HashSet<Client>();
            Employee = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
