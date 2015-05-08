namespace Hiperion.Infrastructure.Automapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public static class AutomapperConfiguration
    {
        public static void Configure(Func<Type, object> serviceLocator = null)
        {
            if (serviceLocator != null)
                Mapper.Configuration.ConstructServicesUsing(serviceLocator);

            IEnumerable<IObjectMapperConfigurator> configurators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof (IObjectMapperConfigurator).IsAssignableFrom(t)
                            && !t.IsAbstract
                            && !t.IsInterface)
                .Select(Activator.CreateInstance).OfType<IObjectMapperConfigurator>();

            foreach (IObjectMapperConfigurator configurator in configurators)
            {
                configurator.Apply();
            }
        }
    }
}