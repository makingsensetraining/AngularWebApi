using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
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