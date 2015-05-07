using System.Data.Entity;
using Hiperion.Infrastructure.EF;

namespace Hiperion
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Http;
    using Castle.Windsor;

    public class Global : HttpApplication
    {
        private static IWindsorContainer _container;

        public IWindsorContainer Container { get { return _container; } }

        void Application_Start(object sender, EventArgs e)
        {
            _container = Bootstrapper.InitializeContainer();

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HiperionDbContext>());
        }
    }
}