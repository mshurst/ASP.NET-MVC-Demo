using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_Demo.Handlers;
using ASP.NET_MVC_Demo.Models;

namespace ASP.NET_MVC_Demo.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepositoryService getUserDataHandler;

        public HomeController(IUserRepositoryService userDataHandler)
        {
            getUserDataHandler = userDataHandler;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Show(UserData user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute("Index");
            }

            var githubUser = await getUserDataHandler.GetUserData(user.Login);

            var repos = await getUserDataHandler.GetUserRepos(user.Login);

            var topReposByStargazerCount = 
                (from repo in repos
                orderby repo.Stargazers_Count descending 
                select repo).Take(5);

            var combinedUserData = new CombinedUserData
            {
                UserData = githubUser,
                UserRepos = topReposByStargazerCount
            };

            return View(combinedUserData);
        }


    }
}