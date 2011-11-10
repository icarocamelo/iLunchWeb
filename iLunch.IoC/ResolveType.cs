using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace iLunch.IoC
{
    public static class ResolveType
    {
        private static IWindsorContainer _windsorContainer;

        private static IWindsorContainer GetIWindsorContainer()
        {
            return _windsorContainer ?? (_windsorContainer = new WindsorContainer());
        }

        public static IWindsorContainer InitializeContainer(IWindsorContainer container)
        {
            _windsorContainer = container;
            return _windsorContainer;
        }

        public static T Of<T>()
        {
            _windsorContainer = GetIWindsorContainer();
            return _windsorContainer.Resolve<T>();
        }

        public static void InstallComponents(params IWindsorInstaller[] installer)
        {
            _windsorContainer = GetIWindsorContainer();
            _windsorContainer.Install(installer);
        }
    }
 
}
