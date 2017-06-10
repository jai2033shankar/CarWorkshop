using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshop.Web.Models
{
    public class AccountModel
    {
        public AccountModel()
        {
            EmailAddress = "";
            LogedIn = false;
        }

        public AccountModel(string email, bool logedIn = false)
        {
            EmailAddress = email;
            LogedIn = logedIn;
        }

        public string EmailAddress { get; set; }

        public bool LogedIn { get; set; }

    }
}
