using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP.NET_MVC_Demo;
using ASP.NET_MVC_Demo.Controllers;
using ASP.NET_MVC_Demo.Handlers;

namespace ASP.NET_MVC_Demo.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new GetUserDataMock());

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Show()
        {
            var getUserData = new GetUserDataMock();
            HomeController controller = new HomeController(getUserData);

            var user = await getUserData.GetUserData("test");

            var result = controller.Show(user);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Show_NullUsernameReturnsNull()
        {
            var getUserData = new GetUserDataMock();

            HomeController controller = new HomeController(getUserData);

            var user = await getUserData.GetUserData("");

            Assert.IsNull(user);
        }
    }
}
