namespace Hiperion.Infrastructure.Ioc
{
    #region References

    using System.Configuration;
    using System.Web.Http;
    using AutoMapper;
    using Automapper;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using EF;
    using EF.Interfaces;
    using Mappings;

    #endregion

    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["HiperionDb"].ConnectionString;
            container.Register(
                Component.For<IMappingEngine>()
                    .UsingFactoryMethod(() => Mapper.Engine),
                Component.For<IDbContext>()
                    .ImplementedBy<HiperionDbContext>()
                    .LifestylePerWebRequest()
                    .DependsOn(Parameter.ForKey("connectionString").Eq(connectionString)),
                Component.For(typeof (EntityResolver<>))
                    .ImplementedBy(typeof (EntityResolver<>))
                    .LifestyleTransient(),
                Component.For(typeof (ManyToManyEntityResolver<,>))
                    .ImplementedBy(typeof (ManyToManyEntityResolver<,>))
                    .LifestyleTransient(),
                Types.FromThisAssembly()
                    .Where(type => (type.Name.EndsWith("Services") ||
                                    type.Name.EndsWith("Repository") ||
                                    type.Name.EndsWith("Resolver") ||
                                    type.Name.EndsWith("Controller")) && type.IsClass)
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );

            AutomapperConfiguration.Configure(container.Resolve);
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}