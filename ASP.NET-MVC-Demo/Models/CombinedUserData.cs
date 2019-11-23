using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Demo.Models
{
    public class CombinedUserData
    {
        public UserData UserData { get; set; }
        public IEnumerable<UserRepo> UserRepos { get; set; }
    }
}