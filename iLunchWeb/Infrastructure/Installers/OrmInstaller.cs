
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using iLunch.Repository.Infrastructure;

namespace iLunchWeb.Infrastructure.Installers
{
    public class OrmInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISession>()
            .LifeStyle.PerWebRequest
            .Instance(SessionProvider.CurrentSession));
        }
    }
}