using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Core.Models
{
    public class User
    {
        public Guid ID { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string IDCardNumber { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        protected User(string firstname, string lastname, string email, string password)
        {
            ID = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            email = Email;
            password = Password;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
