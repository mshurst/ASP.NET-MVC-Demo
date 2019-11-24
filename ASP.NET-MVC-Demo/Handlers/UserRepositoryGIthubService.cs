using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ASP.NET_MVC_Demo.Models;
using Newtonsoft.Json;

namespace ASP.NET_MVC_Demo.Handlers
{
    public class UserRepositoryGIthubService : IUserRepositoryService
    {
        private static string url = @"https://api.github.com/users/";

        public async Task<UserData> GetUserData(string username)
        {
            using (var webRequest = new HttpClient())
            {
                var webRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}{username}");
                webRequestMessage.Headers.Add("User-Agent", "PostmanRuntime/7.20.1");
                var data = await webRequest.SendAsync(webRequestMessage);

                string s = await data.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserData>(s);
            }
        }

        public async Task<IEnumerable<UserRepo>> GetUserRepos(string username)
        {
            using (var webRequest = new HttpClient())
            {
                var webRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}{username}/repos");
                webRequestMessage.Headers.Add("User-Agent", "PostmanRuntime/7.20.1");
                var data = await webRequest.SendAsync(webRequestMessage);

                string s = await data.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<UserRepo>>(s);
            }
        }
    }
}