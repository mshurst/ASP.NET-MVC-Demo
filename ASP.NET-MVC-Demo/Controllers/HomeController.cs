using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_Demo.ErrorHandling;
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
        public async Task<ActionResult> Index(CombinedUserData user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute("Index");
            }

            try
            {
                var combinedUserData = await getUserDataHandler.GetTopReposByUser(user.UserData.Login, 5);

                return View(combinedUserData);
            }
            catch (UserNotFoundException ex)
            {
                ViewBag.Error = "User Not Found";

                return View();
            }
        }
    }
}