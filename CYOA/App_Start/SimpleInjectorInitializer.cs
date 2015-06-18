using System.ComponentModel;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using PathsTakenRepo.Concrete;
using PathsTakenRepo.Interfaces;
using PathsTakenRepo.Concrete;
using PathsTakenRepo.Interfaces;
using Container = SimpleInjector.Container;


[assembly: WebActivator.PreApplicationStartMethod(typeof(Company.Project.Web.SimpleInjectorInitializer), "Initialize")]

namespace Company.Project.Web
{

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {

            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Sql Server
            // container.RegisterPerWebRequest<DbContext, AutoEntities>();
            //container.RegisterPerWebRequest<IRepository, SqlRepository>();

            // Mongo
            var connString = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;
            container.RegisterPerWebRequest<IRepository>(() => new MongoRepository(connString));
        }
    }
}