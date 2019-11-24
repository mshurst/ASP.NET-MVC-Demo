using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Demo.Models
{
    public class UserData
    {
        [Required]
        public string Login { get; set; }
        public int Id { get; set; }
        public string Avatar_Url { get; set; }
        public string Url { get; set; }
        public string Html_Url { get; set; }
        public string Repos_Url { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public int Public_Repos { get; set; }
    }
}