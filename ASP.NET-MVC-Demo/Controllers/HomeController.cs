﻿using System;
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
        private IGetUserData getUserDataHandler;

        public HomeController(IGetUserData userDataHandler)
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
            return View();
        }


    }
}