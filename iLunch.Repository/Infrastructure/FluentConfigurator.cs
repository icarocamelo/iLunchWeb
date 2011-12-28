using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using iLunch.Dominio;
using iLunch.Utils;

namespace iLunch.Repository.Infrastructure
{
    public class FluentConfigurator
    {
        private static Configuration _instance;

        public static Configuration Instance
        {
            get { return _instance ?? GetConfiguration(); }
        }

        private static Configuration GetConfiguration()
        {
            _instance = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(c => c.FromConnectionStringWithKey(Constants.STRING_CONNECTION)))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<User>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Order>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Meal>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Ingredient>())
                .ExposeConfiguration(cfg => cfg.SetProperty(
                                        Environment.CurrentSessionContextClass,
                                        "web")).BuildConfiguration();
            return _instance;
        }

        public static void BuildSchema(Configuration config, bool dropAll, bool createAll)
        {
            if (config == null)
                config = GetConfiguration();

            var schema = new SchemaExport(config);

            if (dropAll)
                schema.Drop(false, true);

            if (createAll)
                schema.Create(false, true);
        }

        public ISessionFactory CreateSessionFactory()
        {
            return GetConfiguration().BuildSessionFactory();
        }
    }
}
