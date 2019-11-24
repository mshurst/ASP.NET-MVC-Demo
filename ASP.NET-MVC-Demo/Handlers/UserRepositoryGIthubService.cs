using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using ASP.NET_MVC_Demo.ErrorHandling;
using ASP.NET_MVC_Demo.Models;
using Newtonsoft.Json;

namespace ASP.NET_MVC_Demo.Handlers
{
    public class UserRepositoryGithubService : IUserRepositoryService
    {
        private static string url = @"https://api.github.com/users/";

        public async Task<UserData> GetUserData(string username)
        {
            var webResponse = await GetWebResponse($"{url}{username}");
            
            string content = await webResponse.Content.ReadAsStringAsync();

            if (!webResponse.IsSuccessStatusCode)
            {
                if (webResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new UserNotFoundException(username);
                }
            }

            return JsonConvert.DeserializeObject<UserData>(content);
            
        }

        public async Task<IEnumerable<UserRepo>> GetUserRepos(string username)
        {
            var webResponse = await GetWebResponse($"{url}{username}/repos");
            string content = await webResponse.Content.ReadAsStringAsync();

            if (!webResponse.IsSuccessStatusCode)
            {
                if (webResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new UserNotFoundException(username);
                }
            }

            List<UserRepo> allRepos = new List<UserRepo>();
            allRepos.AddRange(JsonConvert.DeserializeObject<List<UserRepo>>(content));

            if (webResponse.Headers.Contains("Link"))
            {
                //EXAMPLE:
                //<https://api.github.com/user/1609725/repos?page=1>; rel="prev",
                //<https://api.github.com/user/1609725/repos?page=3>; rel="next",
                //<https://api.github.com/user/1609725/repos?page=3>; rel="last",
                //<https://api.github.com/user/1609725/repos?page=1>; rel="first"
                var strings = webResponse.Headers.GetValues("Link");
                var links = strings.First().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int lastPageCount = 0;
                string pageUrl = "";

                foreach (var link in links)
                {
                    //search for the value which has last id in it
                    if (!link.Contains("last"))
                    {
                        continue;
                    }

                    var newString = link.Trim();                            //trim any spaces, subsequent strings have spaces in them after commas
                    newString = newString.Substring(1);                     //remove leading "<" char
                    newString = newString.Remove(newString.IndexOf(">"));   //">" character denotes end of the URL part of the string

                    lastPageCount = int.Parse(newString.Substring(newString.IndexOf("=") + 1));

                    pageUrl = newString.Substring(0, newString.IndexOf("=")+1); //URL string without integer for page

                }

                //we already have page 1 from first call, so start from page 2
                for (int i = 2; i < lastPageCount; ++i)
                {
                    string fullPageUrl = pageUrl + i;
                    var nextPageResponse = await GetWebResponse(fullPageUrl);
                    string nextPageContent = await nextPageResponse.Content.ReadAsStringAsync();
                    var newRepos = JsonConvert.DeserializeObject<List<UserRepo>>(nextPageContent);
                    allRepos.AddRange(newRepos);
                }
            }

            return allRepos;
        }

        public async Task<CombinedUserData> GetTopReposByUser(string username, int reposCount)
        {
            var userData = await GetUserData(username);

            var allUserRepos = await GetUserRepos(username);

            var topReposByStargazerCount =
                (from repo in allUserRepos
                    orderby repo.Stargazers_Count descending
                    select repo).Take(reposCount);

            var combinedData = new CombinedUserData
            {
                UserData = userData,
                UserRepos = topReposByStargazerCount
            };

            return combinedData;
        }

        private async Task<HttpResponseMessage> GetWebResponse(string fullUrl)
        {
            using (var httpClient = new HttpClient())
            {
                
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("GithubAPIKey", EnvironmentVariableTarget.Machine));
                var webRequest = new HttpRequestMessage(HttpMethod.Get, fullUrl);
                webRequest.Headers.Add("User-Agent", "Custom");
                var response = await httpClient.SendAsync(webRequest);

                return response;
            }
        }
    }
}