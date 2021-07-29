using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TestAssignment.Helpers;
using TestAssignment.Helpers.Interface;
using TestAssignment.Interface;

namespace TestAssignment.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            var servicesAssembly = Assembly.GetAssembly(typeof(IWordCount));
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

            builder.Register(x => new JsonResponseFormatHelper())
               .As<IJsonResponseFormatHelper>().SingleInstance();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}