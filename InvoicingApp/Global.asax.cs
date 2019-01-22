using Autofac;
using Autofac.Integration.Mvc;
using InvoiceApp.Persistence.Repositories;
using InvoiceApp.Persistence.Repository;
using InvoicingApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InvoicingApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IoCConfig.RegisterDependencies();
        }
    }

    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            #region Create the builder
            var builder = new ContainerBuilder();
            #endregion

            #region Setup a common pattern
            // placed here before RegisterControllers as last one wins
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                  .Where(t => t.Name.EndsWith("Controller"));

            //#region Register all controllers for the assembly
            //// Note that ASP.NET MVC requests controllers by their concrete types, 
            //// so registering them As<IController>() is incorrect. 
            //// Also, if you register controllers manually and choose to specify 
            //// lifetimes, you must register them as InstancePerDependency() or 
            //// InstancePerHttpRequest() - ASP.NET MVC will throw an exception if 
            //// you try to reuse a controller instance for multiple requests. 
            //builder.RegisterControllers(typeof(MvcApplication).Assembly)
            //       .InstancePerHttpRequest();

            //#endregion

            //#region Register modules
            //builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            //builder.RegisterModule<AutofacWebTypesModule>();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            #endregion
        }
    }

}
