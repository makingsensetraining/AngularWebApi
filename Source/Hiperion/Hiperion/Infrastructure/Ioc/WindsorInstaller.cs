using System.Configuration;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Configuration.Interpreters;
using Hiperion.Infrastructure.EF;
using Hiperion.Infrastructure.EF.Interfaces;

namespace Hiperion.Infrastructure.Ioc
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["HiperionDb"].ConnectionString;

            container.Register(
                Component.For<IDbContext>()
                         .ImplementedBy<HiperionDbContext>()
                         .LifestylePerWebRequest()
                         .DependsOn(Parameter.ForKey("connectionString").Eq(connectionString)),

                Types.FromThisAssembly()
                        .Where(type => type.Name.EndsWith("Services") ||
                                       type.Name.EndsWith("Repository") ||
                                       type.Name.EndsWith("Controller"))
                        .WithService.DefaultInterfaces()
                        .LifestyleTransient()
            );

            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}