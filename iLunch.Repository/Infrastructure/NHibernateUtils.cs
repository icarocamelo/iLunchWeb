using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using NHibernate;

namespace iLunch.Repository.Infrastructure
{
    public static class NHibernateUtils
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory _sessionFactoryFoaf;

        private static ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory ??
                       (
                           _sessionFactory =
                           Fluently.Configure(FluentConfigurator.Instance).BuildSessionFactory());
            }
        }
        
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
