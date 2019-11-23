using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_Demo.Handlers;

namespace ASP.NET_MVC_Demo.Controllers
{
    public class HomeController : Controller
    {
        private IGetUserData getUserDataHandler;

        public HomeController(IGetUserData userDataHandler)
        {
            getUserDataHandler = userDataHandler;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}