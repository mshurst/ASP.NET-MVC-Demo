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
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ASP.NET_MVC_Demo.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private Mock<IUserRepositoryService> mockUserRepositoryService;

        [Test]
        public void Index_Always_ViewReturns()
        {
            Mock<IUserRepositoryService> mockUserRepositoryService = new Mock<IUserRepositoryService>(MockBehavior.Strict);

            // Arrange
            HomeController controller = new HomeController(mockUserRepositoryService.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
