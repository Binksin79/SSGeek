using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SSGeek.DAL;

namespace SSGeek
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
        // Configure the dependency injection container.
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            string connectionString = @"Server =.\SQLEXPRESS; Database = SSGeek; Trusted_Connection = True";

            // Set up the bindings
            kernel.Bind<IForumPostDAL>().To<ForumPostSqlDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IProductDAL>().To<ProductSqlDAL>().WithConstructorArgument("connectionString", connectionString);
            return kernel;
        }
    }
}
