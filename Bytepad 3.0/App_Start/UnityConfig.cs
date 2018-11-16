using Bytepad_3._0.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Bytepad_3._0
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IExamType, ExamType>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}