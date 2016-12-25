using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebServiceMarvel.Attributes
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public string Password { get; set; }

        public BasicAuthenticationIdentity(string username, string password)
            : base(username, "Basic")
        {
            this.Password = password;
        }
    }
}