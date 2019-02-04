using Autofac;
using Autofac.Integration.Mvc;
using InvoiceApp.Persistence;
using InvoiceApp.Persistence.Repositories;
using InvoiceApp.Persistence.Repository;
using InvoiceApp.Persistence.Services;
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

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //not managable

            //builder.RegisterType<CompanyController>().InstancePerRequest();
            //builder.RegisterType<ProductController>().InstancePerRequest();
            //builder.RegisterType<InvoiceController>().InstancePerRequest();

            builder.RegisterType<InvoiceAppDbContext>().InstancePerRequest();

            #region Setup a common pattern
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(OtherRepository<>)).As(typeof(IOtherRepository<>)).InstancePerLifetimeScope() ;


            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerRequest();
            builder.RegisterType<ProductService>().As<IProductSevice>().InstancePerRequest(); 
            builder.RegisterType<InvoiceService>().As<IInvoiceService>().InstancePerRequest();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //       .Where(t => t.Name.EndsWith("Service"))
            //       .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //      .Where(t => t.Name.EndsWith("Controller"));


            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            #endregion
        }
    }

}
