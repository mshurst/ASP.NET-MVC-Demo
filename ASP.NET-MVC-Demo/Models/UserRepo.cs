using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Demo.Models
{
    public class UserRepo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public UserData Owner { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Stargazers_Count { get; set; }
    }
}