using Castle.MicroKernel.Registration;
using Hiperion.Infrastructure.EF;
using Hiperion.Infrastructure.EF.Interfaces;

namespace Hiperion.Infrastructure.Ioc
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbContext>()
                    .ImplementedBy<UserContext>()
                    .LifestylePerWebRequest(),

                AllTypes.FromThisAssembly()
                        .Where(type => type.Name.EndsWith("Services") ||
                                       type.Name.EndsWith("Repository") ||
                                       type.Name.EndsWith("Controller"))
                        .WithService.DefaultInterfaces()
                        .LifestyleTransient()
            );
        }
    }
}