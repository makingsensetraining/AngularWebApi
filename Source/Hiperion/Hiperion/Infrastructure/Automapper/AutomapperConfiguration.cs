namespace Hiperion.Infrastructure.Automapper
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class AutomapperConfiguration
    {
        public static void Configure(Func<Type, object> serviceLocator = null)
        {
            var configurators = Assembly.GetExecutingAssembly().GetTypes()
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