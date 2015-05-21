#region References

using Hiperion;
using Microsoft.Owin;

#endregion

[assembly: OwinStartup(typeof (Startup))]

namespace Hiperion
{
    #region References

    using System;
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.Windsor;
    using Infrastructure.EF;
    using Microsoft.Owin.Cors;
    using Microsoft.Owin.Security.OAuth;
    using Owin;
    using Services.Interfaces;

    #endregion

    public class Startup
    {
        private static IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public void Configuration(IAppBuilder app)
        {
            _container = Bootstrapper.InitializeContainer();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var config = new HttpConfiguration();
            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HiperionDbContext>());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var userServices = _container.Resolve<IUserServices>();


            var OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(userServices)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}