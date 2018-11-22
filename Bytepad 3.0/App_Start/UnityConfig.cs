using Bytepad_3._0.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace Bytepad_3._0
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IExamType, ExamType>();
            container.RegisterType<ISession, Session>();
            container.RegisterType<ISemester, Semester>();
            container.RegisterType<ISubject, Subject>();
            container.RegisterType<IPaper, Paper>();
            container.RegisterType<IFillPaper, FillPaper>();
            container.RegisterType<ILogin, Login>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}