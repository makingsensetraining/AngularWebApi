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
    using Hiperion.Infrastructure.Ioc;
    using Microsoft.Owin.Security.Facebook;
    using Hiperion.Providers;
    using System.Configuration;

    #endregion

    public class Startup
    {
        private static IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public static OAuthBearerAuthenticationOptions MainOAuthBearerOptions { get; private set; }
        public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            _container = Bootstrapper.InitializeContainer();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var config = new HttpConfiguration();
            config.DependencyResolver = new WindsorDependencyResolver(_container);

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HiperionDbContext>());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            MainOAuthBearerOptions = new OAuthBearerAuthenticationOptions();

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
            app.UseOAuthBearerAuthentication(MainOAuthBearerOptions);

            // Configure Facebook External Login.
            FacebookAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId =  ConfigurationManager.AppSettings.Get("FacebookAppId"),
                AppSecret = ConfigurationManager.AppSettings.Get("FacebookAppSecret"),
                Provider = new FacebookAuthProvider()
            };

            app.UseFacebookAuthentication(FacebookAuthOptions);
        }
    }
}