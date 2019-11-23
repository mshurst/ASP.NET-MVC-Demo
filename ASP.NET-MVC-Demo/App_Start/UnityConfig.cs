using System.Web.Mvc;
using ASP.NET_MVC_Demo.Handlers;
using Unity;
using Unity.Mvc5;

namespace ASP.NET_MVC_Demo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IGetUserData, GetUserDataGithub>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}