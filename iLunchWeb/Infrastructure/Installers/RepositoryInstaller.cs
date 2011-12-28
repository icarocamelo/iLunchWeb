using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using iLunch.Dominio;
using iLunch.Repository.Infrastructure;
using iLunch.Repository.Interfaces;

namespace iLunchWeb.Infrastructure.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindRepositories().Configure(ConfigureRepositories()));
        }

        private static ConfigureDelegate ConfigureRepositories()
        {
            return c => c.LifeStyle.PerWebRequest;
        }

        public BasedOnDescriptor FindRepositories()
        {
            return AllTypes.FromAssemblyContaining<FluentConfigurator>()
                .BasedOn(typeof(IRepository<>))
                .WithService
                .DefaultInterface();
        }
    }
}
