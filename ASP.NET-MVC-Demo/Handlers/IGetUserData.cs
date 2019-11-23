using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_MVC_Demo.Models;

namespace ASP.NET_MVC_Demo.Handlers
{
    public interface IGetUserData
    {
        Task<UserData> GetUserData(string username);
    }
}
