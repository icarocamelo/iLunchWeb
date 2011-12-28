using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using iLunch.Repository.Infrastructure;
using iLunchWeb.Infrastructure;
using iLunchWeb.Infrastructure.Installers;

namespace iLunchWeb
{
    public class MvcApplication : HttpApplication
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            //FluentConfigurator.BuildSchema(null, true, true);
            Container.Install(
                new RepositoryInstaller(),
                new ControllerInstaller(),
                new OrmInstaller()
                );

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(Container.Kernel));//ControllerBuilder.Current.SetControllerFactory((typeof(CustomControllerFactory));
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            
           
        }
    }
}