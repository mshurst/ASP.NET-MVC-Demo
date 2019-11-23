using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ASP.NET_MVC_Demo.Models;

namespace ASP.NET_MVC_Demo.Handlers
{
    public class GetUserDataMock : IGetUserData
    {
        public async Task<UserData> GetUserData(string username)
        {
            UserData user = new UserData();
            user.Login = "MOCK";

            return user;
        }
    }
}