using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Hiperion.Infrastructure.Ioc;

namespace Hiperion
{
    public static class Bootstrapper
    {
        public static IWindsorContainer InitializeContainer()
        {
            return new WindsorContainer().Install(new WindsorInstaller());
        }

        public static void Release(IWindsorContainer container)
        {
            container.Dispose();
        }
    }
}