using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Demo.Models
{
    public class UserRepo
    {
        public int Id { get; set; }
        public string Node_Id { get; set; }
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public bool Private { get; set; }
        public UserData Owner { get; set; }
        public string Html_Url { get; set; }
        public string Description { get; set; }
        public bool Fork { get; set; }
        public string Url { get; set; }
        public string Forks_Url { get; set; }
        public string Keys_url { get; set; }
        public string Collaboration_Url { get; set; }
        public string Teams_Url { get; set; }
        public string Hooks_Url { get; set; }
        //todo add other Url properties
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Pushed_At { get; set; }
        public string Git_Url { get; set; }
        public string Ssh_Url { get; set; }
        public string Cone_Url { get; set; }
        public string Svn_Url { get; set; }
        public string Homepage { get; set; }
        public int Size { get; set; }
        public int Stargazers_Count { get; set; }
        public int Watchers_Count { get; set; }
        public string Language { get; set; }
        public bool Has_Issues { get; set; }
        public bool Has_Projects { get; set; }
        public bool Has_Downloads { get; set; }
        public bool Has_Wiki { get; set; }
        public bool Has_Pages { get; set; }
        public int Forks_Count { get; set; }
        public string Mirror_Url { get; set; }
        public bool Archived { get; set; }
        public bool Disabled { get; set; }
        public int Open_Issues_Count { get; set; }
        public int Forks { get; set; }
        public Licence Licence { get; set; }
        public int Open_Issues { get; set; }
        public int Watchers { get; set; }
        public string Default_Branch { get; set; }
    }

    public class Licence
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Spdx_Id { get; set; }
        public string Url { get; set; }
        public string Node_Id { get; set; }
    }
}