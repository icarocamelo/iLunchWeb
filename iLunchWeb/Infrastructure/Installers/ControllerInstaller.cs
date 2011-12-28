using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace iLunchWeb.Infrastructure.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().Configure(ConfigureControllers()));
        }

        private static ConfigureDelegate ConfigureControllers()
        {
            return c => c.LifeStyle.PerWebRequest;
        }

        public BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromThisAssembly()
                 .BasedOn<Controller>();
        }
    }
}
