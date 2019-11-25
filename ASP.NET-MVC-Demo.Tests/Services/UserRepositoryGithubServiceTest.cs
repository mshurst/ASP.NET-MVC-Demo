using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_MVC_Demo.ErrorHandling;
using ASP.NET_MVC_Demo.Handlers;
using ASP.NET_MVC_Demo.Models;
using NUnit.Framework;

namespace ASP.NET_MVC_Demo.Tests.Services
{
    [TestFixture]
    public class UserRepositoryServiceTest
    {
        [Test]
        public async Task GetUserData_UserNotFoundException_KnownMissingUser()
        {
            var service = new UserRepositoryGithubService();

            Assert.ThrowsAsync<UserNotFoundException>(() => service.GetUserData("nvrjei rnbrjib bnij"));
        }

        [Test]
        public async Task GetUserData_UserNotFoundException_EmptyString()
        {
            var service = new UserRepositoryGithubService();

            Assert.ThrowsAsync<UserNotFoundException>(() => service.GetUserData(string.Empty));
        }

        [Test]
        public async Task GetUserData_UserNotFoundException_NullString()
        {
            var service = new UserRepositoryGithubService();

            Assert.ThrowsAsync<UserNotFoundException>(() => service.GetUserData(null));
        }

        [Test]
        public async Task GetUserData_ValidResponse_ValidUser()
        {
            string validUser = "microsoft";
            var service = new UserRepositoryGithubService();

            var response = await service.GetUserData(validUser);

            Assert.NotNull(response);
            Assert.AreEqual(validUser, response.Login);
        }

        [Test]
        public async Task GetUserRepos_UserNotFoundException_KnownMissingUser()
        {
            var service = new UserRepositoryGithubService();

            Assert.ThrowsAsync<UserNotFoundException>(() => service.GetUserRepos("njreinbre nbjibnn"));
        }

        [Test]
        public async Task GetUserRepos_UserNotFoundException_EmptyString()
        {
            var service = new UserRepositoryGithubService();

            Assert.ThrowsAsync<UserNotFoundException>(() => service.GetUserRepos(string.Empty));
        }

        [Test]
        public async Task GetUserRepos_UserNotFoundException_NullString()
        {
            var service = new UserRepositoryGithubService();

            Assert.ThrowsAsync<UserNotFoundException>(() => service.GetUserRepos(null));
        }

        [Test]
        public async Task GetUserRepos_ValidResponse_ValidUser()
        {
            string validUser = "bennuttall";

            var service = new UserRepositoryGithubService();

            var response = await service.GetUserRepos(validUser);

            Assert.NotNull(response);
            Assert.AreEqual(validUser, response.First().Owner.Login);
        }
    }
}
