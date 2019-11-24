using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Demo.ErrorHandling
{
    public class UserNotFoundException : Exception
    {
        public string Username { get; set; }

        public UserNotFoundException(string username)
        {
            Username = username;
        }
    }
}