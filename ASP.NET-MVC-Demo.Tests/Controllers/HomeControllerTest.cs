using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ASP.NET_MVC_Demo;
using ASP.NET_MVC_Demo.Controllers;
using ASP.NET_MVC_Demo.Handlers;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ASP.NET_MVC_Demo.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_Always_ViewReturns()
        {
            // Arrange
            HomeController controller = new HomeController(new GetUserDataMock());

            // Act
            var result = controller.Index();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Show_Always_ViewReturns()
        {
            var getUserData = new GetUserDataMock();
            HomeController controller = new HomeController(getUserData);

            var user = await getUserData.GetUserData("test");

            var result = controller.Show(user);

            Assert.That(true, Is.True);
        }

        [Test]
        public async Task Show_NullUsername_ReturnsNull()
        {
            var getUserData = new GetUserDataMock();

            HomeController controller = new HomeController(getUserData);

            var user = await getUserData.GetUserData("");

            Assert.That(user, Is.Null);
        }
    }
}
