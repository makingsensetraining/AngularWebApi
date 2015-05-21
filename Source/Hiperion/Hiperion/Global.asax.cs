namespace Hiperion
{
    #region References

    using System;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.Windsor;
    using Infrastructure.EF;

    #endregion

    public class Global : HttpApplication
    {
        //private static IWindsorContainer _container;

        //public IWindsorContainer Container
        //{
        //    get { return _container; }
        //}

        private void Application_Start(object sender, EventArgs e)
        {
            //_container = Bootstrapper.InitializeContainer();

            //// Code that runs on application startup
            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HiperionDbContext>());
        }
    }
}