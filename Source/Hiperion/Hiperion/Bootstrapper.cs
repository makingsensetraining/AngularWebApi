namespace Hiperion
{
    #region References

    using Castle.Windsor;
    using Infrastructure.Ioc;

    #endregion

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