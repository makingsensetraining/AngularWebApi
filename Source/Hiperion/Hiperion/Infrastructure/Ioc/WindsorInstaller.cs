namespace Hiperion.Infrastructure.Ioc
{
    using System.Configuration;
    using System.Web.Http;
    using Automapper;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using EF;
    using EF.Interfaces;

    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HiperionDb"].ConnectionString;

            container.Register(
                Component.For<IDbContext>()
                    .ImplementedBy<HiperionDbContext>()
                    .LifestylePerWebRequest()
                    .DependsOn(Parameter.ForKey("connectionString").Eq(connectionString)),
                Types.FromThisAssembly()
                    .Where(type => (type.Name.EndsWith("Services") ||
                                    type.Name.EndsWith("Repository") ||
                                    type.Name.EndsWith("Controller")) && type.IsClass)
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );

            AutomapperConfiguration.Configure(container.Resolve);
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}